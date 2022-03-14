using TechnoLogica.RegiX.DummyAdapter;

namespace RegiX.Adapters.Mocks.Tests
{
    public class DummyTestAdapterServiceNETCoreMock : BaseAdapterServiceProxy<IDummyTestAdapterServiceNETCore>
    {
        static DummyTestAdapterServiceNETCoreMock()
        {
            RegisterResolver<ExampleRequestType, ExampleResponse>(
                (i, r, a, o) => i.CustomResponse(r, a, o),
                fileNameResolver: (r) => ResolveCustomResponseName(r)
            );

            RegisterResolver<ExampleRequestType, ExampleResponse>(
                (i, r, a, o) => i.Augmented(r, a, o),                
                augmentActionResolver: (r) => AugmentResponse(r)
            );
        }

        static string ResolveCustomResponseName(ExampleRequestType r)
        {
            return @"\XMLData\RegiX.Adapters.Mocks.Tests\Custom.response.xml";
        }

        private static void AugmentResponse(ExampleResponse r)
        {
            r.StringData = "Augmented";
        }

    }
}
