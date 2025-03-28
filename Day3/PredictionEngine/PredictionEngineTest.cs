using Moq;

namespace PredictionEngine.Tests;

public class PredictionEngineTest
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("Hello","Hello")]
    [TestCase("Hello how are you do", "do")]
    [TestCase(" ", "")]
    public void ShouldCallUnigramWhenPartialWordIsGiven(string phrase, string lastword)
    {
        var mockAlgo = new Mock<ILanguageModelAlgo>();
        PredictionEngine predictionAgent = new PredictionEngine(mockAlgort.Object);

        string prediction = predictionAgent.Predict("phrase");

        mockAlgo.Verify(p => p.predictUsingMonogram("lastword"), Times.Once());
    }

    [TestCase("Hello ", "Hello")]
    [TestCase("Hello how are you", "you")]
    [TestCase(" ","")]
    public void ShouldCalBigramWhenPhraseEndsWithSpace(string phrase, string lastword)
    {
        var mockAlgo = new Mock<ILanguageModelAlgo>();
        PredictionEngine predictionAgent = new PredictionEngine(mockAlgort.Object);

        string prediction = predictionAgent.Predict("phrase");

        mockAlgo.Verify(p => p.predictUsingBigram("lastword"), Times.Once());
    }

    
}
