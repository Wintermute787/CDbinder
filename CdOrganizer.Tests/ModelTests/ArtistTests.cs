using Microsoft.VisualStudio.TestTools.UnitTesting;
using CdOrganizer.Models;
using System.Collections.Generic;
using System;

namespace CdOrganizer.Tests
{
  [TestClass]
  public class ArtistTest : IDisposable
  //This code will allow dispose to clear data for tests
  {

    public void Dispose()
    {
      Artist.ClearAll();
    }
    [TestMethod]
    public void ArtistConstructor_CreatesInstanceOfArtist_Artist()
    {
      Artist newArtist = new Artist("Test Artist");
      // Assert.AreEqual(typeof(int), newArtist.GetType());//Makes this test fail

      Assert.AreEqual(typeof(Artist), newArtist.GetType());
      //This will make the test pass
    }
      [TestMethod]
      public void GetName_ReturnsName_String()
    {
      string name = "Test Artist";
      Artist newArtist = new Artist(name);

      string result = newArtist.GetName();

      // Assert.AreEqual("jim", result);//This will make the test fail
      Assert.AreEqual(name, result);
      //This will make the test pass
    }

    [TestMethod]
    public void GetId_ReturnsArtistId_Int()
    {
      string name = "Test Artist";
      Artist newArtist = new Artist(name);

      int result = newArtist.GetId();

      // Assert.AreEqual(2, result);//This will make the test fail
      Assert.AreEqual(1,result);
      //this will make the test pass.
    }

    [TestMethod]
    public void GetAll_ReturnsAllArtistObjects_ArtistList()
    {
      // string name03 = "Joe";
      // string name04 = "Marc";
      // Artist newArtist3 = new Artist(name03);
      // Artist newArtist4 = new Artist(name04);
      // List<Artist> secondList = new List<Artist> {newArtist3, newArtist4};//Add this to make Test Fail

      string name01 = "Celine Dion";
      string name02 = "Taylor Swift";
      Artist newArtist1 = new Artist(name01);
      Artist newArtist2 = new Artist(name02);
      List<Artist> newList = new List<Artist> {newArtist1, newArtist2};

      List<Artist> result = Artist.GetAll();

      CollectionAssert.AreEqual(newList, result);

    }

    [TestMethod]
    public void Find_ReturnsCorrectArtist_Artist()
    {
      string name1 = "joe";
      string name2 = "marc";
      Artist newArtist1 = new Artist(name1);
      Artist newArtist2 = new Artist(name2);

      Artist result = Artist.Find(2);

      // Assert.AreEqual(newArtist1, result);//THis will make the test Fail
      Assert.AreEqual(newArtist2, result);
    }

    [TestMethod]
    public void GetItems_ReturnsEmptyCdList_CdList()
    {
      string name = "Killers";
      Artist newArtist = new Artist(name);
      List<CD> newList = new List<CD>{};

      List<CD> result = newArtist.GetCD();

      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void AddTitle_AssociatesTitleWithArtist_TitleList()
    {
      string title = "Killers";
      CD newCD = new CD(title);
      List<CD> newList = new List<CD>{newCD};
      string artist = "Iron Maiden";
      Artist newArtist = new Artist(artist);
      newArtist.AddCD(newCD);

      List<CD> result = newArtist.GetCD();

      CollectionAssert.AreEqual(newList, result);
    }


  }
}
