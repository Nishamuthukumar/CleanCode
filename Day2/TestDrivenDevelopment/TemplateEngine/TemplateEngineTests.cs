namespace TemplateEngine.Tests
{
    public class TemplateEngineTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldValidateForSingleVariable()
        {
            TemplateEngine templateEngine = new TemplateEngine();
            templateEngine.SetTemplate("Hello {name}");
            templateEngine.SetVariable("name", "Nisha"); 
            string result = templateEngine.Evaluate();
            Assert.That(result, Is.EqualTo("Hello Nisha"));
        }

        [TestCase("Nisha")]
        public void ShouldValidateForSingleVariableWithDifferentValues(string value)
        {
            TemplateEngine templateEngine = new TemplateEngine();
            templateEngine.SetTemplate("Hello {name}");
            templateEngine.SetVariable("name", value); 
            string result = templateEngine.Evaluate();
            Assert.That(result, Is.EqualTo($"Hello {value}"));
        }

        [TestCase("Nisha", "M")]
        public void ShouldValidateForTwoVariables(string value1, string value2)
        {
            TemplateEngine templateEngine = new TemplateEngine();
            templateEngine.SetTemplate("Hello {Firstname} {Lastname}");
            templateEngine.SetVariable("Firstname", value1);
            templateEngine.SetVariable("Lastname", value2);
            string result = templateEngine.Evaluate();
            Assert.That(result, Is.EqualTo($"Hello {value1} {value2}"));
        }
    }
}
