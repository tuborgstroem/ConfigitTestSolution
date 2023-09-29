

using ConfigitSolution.Services;

namespace ConfigitSolutionsTests;

public class Tests
{
    private PackageAnalyzer packageAnalyzer; 
    
    [SetUp]
    public void Setup()
    {
        packageAnalyzer = new PackageAnalyzer();
        
    }
    
    
    [Test]
    public void Test0Pass()
    {
        string testInputPass = "1\nP1,42\n1\nP1,42,P2,Beta-1";
        
        bool res = packageAnalyzer.analyzePackage(testInputPass);
        
        Assert.True(res);
    }
    
    [Test]
    public void Test1Fail()
    {
        string testInputPass = "1\nA,1\n2\nA,1,B,2\nA,1,B,1\n";
        
        bool res = packageAnalyzer.analyzePackage(testInputPass);

        Assert.False(res);
    }
    
    [Test]
    public void Test2Fail()
    {
        string testInputPass = "1\nB,2\n2\nB,2,A,1,C,1\nC,1,A,2";
        
        bool res = packageAnalyzer.analyzePackage(testInputPass);

        Assert.False(res);
    }

    [Test]
    public void Test3Pass()
    {
        string testInputPass = "1\nB,1\n1\nB,1,B,1";
        
        bool res = packageAnalyzer.analyzePackage(testInputPass);

        Assert.True(res);
    }
    
    [Test]
    public void Test4Pass(){
        string testInputPass = "2\nA,2\nB,2\n3\nA,1,B,1\nA,1,B,2\nA,2,C,3";
        
        bool res = packageAnalyzer.analyzePackage(testInputPass);

        Assert.True(res);
    }
    
    [Test]
    public void Test5Fail(){
        string testInputPass = "2\nA,2\nB,2\n5\nA,1,B,1\nA,1,B,2\nA,2,C,3\nC,3,D,4\nD,4,B,1";
        
        bool res = packageAnalyzer.analyzePackage(testInputPass);

        Assert.False(res);
    }
    
    [Test]
    public void Test6Pass(){
        string testInputPass = "1\nB,2\n2\nA,1,B,2\nB,2,A,1\n";
        
        bool res = packageAnalyzer.analyzePackage(testInputPass);

        Assert.True(res);
    }
    
    [Test]
    public void Test7Fail(){
        string testInputPass = "2\nA,1\nC,1\n2\nA,1,B,1\nC,1,B,2";
        
        bool res = packageAnalyzer.analyzePackage(testInputPass);

        Assert.False(res);
    }
    
    [Test]
    public void Test8Pass(){
        string testInputPass = "1\nA,1";
        
        bool res = packageAnalyzer.analyzePackage(testInputPass);

        Assert.True(res);
    }
    
    [Test]
    public void Test9Pass(){
        string testInputPass = "3\nA,2\nB,2\nG,1\n5\nA,1,B,2\nA,2,C,3\nC,3,D,4\nD,4,G,1\nG,1,B,2";
        
        bool res = packageAnalyzer.analyzePackage(testInputPass);

        Assert.True(res);
    }
}