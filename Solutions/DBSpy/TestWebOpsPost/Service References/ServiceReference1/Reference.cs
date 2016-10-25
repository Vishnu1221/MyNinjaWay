﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestWebOpsPost.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WebOpsEntity", Namespace="")]
    [System.SerializableAttribute()]
    public partial class WebOpsEntity : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string firstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool invertoryOrderField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string invoice_NumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string lastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool timeSentInGMTField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string firstName {
            get {
                return this.firstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.firstNameField, value) != true)) {
                    this.firstNameField = value;
                    this.RaisePropertyChanged("firstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool invertoryOrder {
            get {
                return this.invertoryOrderField;
            }
            set {
                if ((this.invertoryOrderField.Equals(value) != true)) {
                    this.invertoryOrderField = value;
                    this.RaisePropertyChanged("invertoryOrder");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string invoice_Number {
            get {
                return this.invoice_NumberField;
            }
            set {
                if ((object.ReferenceEquals(this.invoice_NumberField, value) != true)) {
                    this.invoice_NumberField = value;
                    this.RaisePropertyChanged("invoice_Number");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string lastName {
            get {
                return this.lastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.lastNameField, value) != true)) {
                    this.lastNameField = value;
                    this.RaisePropertyChanged("lastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool timeSentInGMT {
            get {
                return this.timeSentInGMTField;
            }
            set {
                if ((this.timeSentInGMTField.Equals(value) != true)) {
                    this.timeSentInGMTField = value;
                    this.RaisePropertyChanged("timeSentInGMT");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IOrderCreation")]
    public interface IOrderCreation {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IOrderCreation/ProcessRequest")]
        void ProcessRequest(TestWebOpsPost.ServiceReference1.WebOpsEntity webopsObj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderCreation/getOrder", ReplyAction="http://tempuri.org/IOrderCreation/getOrderResponse")]
        TestWebOpsPost.ServiceReference1.WebOpsEntity getOrder(string orderID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderCreation/getOrderWrapped", ReplyAction="http://tempuri.org/IOrderCreation/getOrderWrappedResponse")]
        TestWebOpsPost.ServiceReference1.WebOpsEntity getOrderWrapped(string orderID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderCreation/xmlData", ReplyAction="http://tempuri.org/IOrderCreation/xmlDataResponse")]
        string xmlData(string id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOrderCreationChannel : TestWebOpsPost.ServiceReference1.IOrderCreation, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OrderCreationClient : System.ServiceModel.ClientBase<TestWebOpsPost.ServiceReference1.IOrderCreation>, TestWebOpsPost.ServiceReference1.IOrderCreation {
        
        public OrderCreationClient() {
        }
        
        public OrderCreationClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OrderCreationClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrderCreationClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrderCreationClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void ProcessRequest(TestWebOpsPost.ServiceReference1.WebOpsEntity webopsObj) {
            base.Channel.ProcessRequest(webopsObj);
        }
        
        public TestWebOpsPost.ServiceReference1.WebOpsEntity getOrder(string orderID) {
            return base.Channel.getOrder(orderID);
        }
        
        public TestWebOpsPost.ServiceReference1.WebOpsEntity getOrderWrapped(string orderID) {
            return base.Channel.getOrderWrapped(orderID);
        }
        
        public string xmlData(string id) {
            return base.Channel.xmlData(id);
        }
    }
}
