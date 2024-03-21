﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControllerHost.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IServiceController")]
    public interface IServiceController {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceController/ReadPort", ReplyAction="http://tempuri.org/IServiceController/ReadPortResponse")]
        string ReadPort();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceController/ReadPort", ReplyAction="http://tempuri.org/IServiceController/ReadPortResponse")]
        System.Threading.Tasks.Task<string> ReadPortAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceControllerChannel : ControllerHost.ServiceReference.IServiceController, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceControllerClient : System.ServiceModel.ClientBase<ControllerHost.ServiceReference.IServiceController>, ControllerHost.ServiceReference.IServiceController {
        
        public ServiceControllerClient() {
        }
        
        public ServiceControllerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceControllerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceControllerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceControllerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string ReadPort() {
            return base.Channel.ReadPort();
        }
        
        public System.Threading.Tasks.Task<string> ReadPortAsync() {
            return base.Channel.ReadPortAsync();
        }
    }
}