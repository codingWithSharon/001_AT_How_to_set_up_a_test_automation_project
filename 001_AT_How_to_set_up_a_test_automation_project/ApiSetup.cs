using NUnit.Framework;
using _001_AT_How_to_set_up_a_test_automation_project.APITests.Helpers.SpecificHelper;

namespace Microsoft.Playwright.NUnit;

public class ApiSetup : ContextTest
{
    public IPage Page { get; private set; } = null!;
    public IAPIRequestContext IAPIRequestContext { get; private set; } = null!;

    public VroegPiekenHelper vroegPiekenHelper = null!;
    public AutomationExerciseHelper automationExerciseHelper = null!;

    //public ABNAPIHelper aBNAPIHelper = null!;
    //public AchmeaHelper? achmeaHelper = null;
    //public ConnectHelper connectHelper = null!;
    //public DossierRequestPoolDataHelper? dossierRequestPoolDataHelper = null;
    //public EvidesHelper? evidesHelper = null;
    //public FlidsApiHelper flidsApiHelper = null!;
    //public KvkHelper kvkHelper = null!;
    //public OpdrachtGeverPortalApiHelper opdrachtGeverPortalApiHelper = null!;
    //public ReadEventsHelper? readEventsHelper = null;
    //public SagasHelper sagasHelper = null!;
    //public RequestHelper requestHelper = null!;
    //public SetUpTestDataForUITests? setUpTestDataForUITests = null;

    [OneTimeSetUp]
    public async Task PageSetupAPi()
    {
        //var playwright = GlobalSetup.Playwright;
        //var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        //{
        //    Headless = true
        //});
        //var Context = await browser.NewContextAsync();
        //Page = await Context.NewPageAsync().ConfigureAwait(true);
        //Page.SetDefaultTimeout(6000);
        //IAPIRequestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
        //{
        //    Timeout = 300000
        //});

        vroegPiekenHelper = new VroegPiekenHelper(IAPIRequestContext);
        automationExerciseHelper = new AutomationExerciseHelper(IAPIRequestContext);

        //aBNAPIHelper = new ABNAPIHelper(IAPIRequestContext);
        //achmeaHelper = new AchmeaHelper(IAPIRequestContext);
        //connectHelper = new ConnectHelper(IAPIRequestContext);
        //dossierRequestPoolDataHelper = new DossierRequestPoolDataHelper(IAPIRequestContext);
        //evidesHelper = new EvidesHelper(IAPIRequestContext);
        //flidsApiHelper = new FlidsApiHelper(IAPIRequestContext);
        //kvkHelper = new KvkHelper(IAPIRequestContext);
        //readEventsHelper = new ReadEventsHelper();
        //opdrachtGeverPortalApiHelper = new OpdrachtGeverPortalApiHelper();
        //sagasHelper = new SagasHelper(IAPIRequestContext);
        //requestHelper = new RequestHelper(IAPIRequestContext);
        //setUpTestDataForUITests = new SetUpTestDataForUITests(IAPIRequestContext);


        //TokenStorage.Configure(requestHelper);
        //readEventsHelper.SetupEventReader();

    }

    [OneTimeTearDown]
    public async Task TearDown()
    {
        await Page.CloseAsync();
    }

}