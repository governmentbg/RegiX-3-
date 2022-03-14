# RegiX.IaosTraderBrokerAdapter
Added GetTRADER_BROKER_Waste_Codes_By_EIKV2 operation
The configuration for Security.Mode for V2 operation is in Reference.cs in method 

private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.TraderBrokerServiceImplPort))
            {
               
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.None;
               
            }
        }

        By default it is Transport. Changed to None because the service is hosted under Http. The change is made by hand, because it can't be overrided.