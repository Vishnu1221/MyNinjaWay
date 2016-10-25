using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestServiceForCreation.UpsscModel;
using AutoMapper;

namespace TestServiceForCreation.BAL
{
    public static class MapToSPLUS
    {
        /// <summary>
        /// Map WebOps Entity to UPS Entity
        /// </summary>
        /// <param name="webopsObj">Webops Entity</param>
        public static void MapWebopsToSPLUS(WebOpsEntity webopsObj)
        {
            Mapper.CreateMap<WebOpsEntity, OrderProcessingInstructions>()
            .ForMember(ordprs => ordprs.customerOrderNumber, opt => opt.MapFrom(src => src.invoice_Number))
            .ForMember(ordprs => ordprs.inventoryOrder, opt => opt.MapFrom(src => src.invertoryOrder))
            .ForMember(ordprs => ordprs.timeSentInGMT, opt => opt.MapFrom(src => src.timeSentInGMT));

            Mapper.CreateMap<WebOpsEntity, Authorizer>()
           .ForMember(aut => aut.firstName, opt => opt.MapFrom(src => src.firstName))
           .ForMember(aut => aut.lastName, opt => opt.MapFrom(src => src.lastName));
            //Map to destination Entity
            OrderProcessingInstructions ordprc = Mapper.Map<WebOpsEntity, OrderProcessingInstructions>(webopsObj);
            //Map to destination Entity
            Authorizer auth = Mapper.Map<WebOpsEntity, Authorizer>(webopsObj);
            OrderCreationRequest ordcrt = new OrderCreationRequest();
            ordcrt.orderProcessing = ordprc;
            ordcrt.authorize = auth;
            Header header1 = new Header();
            header1.messageConsumer = "SplusAdapter";
            header1.messageFunction = "OrderCreationRequest";
            header1.messageIdentifier = "test-1000830107";
            header1.messageProducer = "SIP";
            header1.processIdentifier = "897537096";
            header1.messageDateTime = DateTime.Now;
            Upsscs ups = new Upsscs();
            ups.applicationVersion = "1.0";
            ups.schemaVersion = "5.1";
            ups.header = header1;
            ups.oderCreation = ordcrt;
            //Call method to convert to xml
            ConvertToUPSXML.ConvertToXML(ups);       
        }
    }
} 