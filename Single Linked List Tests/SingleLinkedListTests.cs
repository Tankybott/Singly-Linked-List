using NUnit.Framework;
using System.Linq;

namespace Single_Linked_List_Tests
{
    [TestFixture]
    public class SingleLinkedListTests
    {
        #region ConstructorTests;
        [Test]
        public void Constructor_ShallThrowAnException_IfArgumentIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new SingleLinkedList<int>(null));
        }

        [Test]
        public void Constructor_ShouldProperlyCopyArrayToList_IfArgumentIsArrayWithValues()
        {
            var inputArray = new int[] { 1, 2, 3, 4, 5 };

            var list = new SingleLinkedList<int>(inputArray);

            for (int i = 0; i < inputArray.Length; i++)
            {
                Assert.That(list.GetAt(i), Is.EqualTo(inputArray[i]));
            }
        }

        [Test]
        public void Constructor_ListShouldHaveProperCount_WhenArrayCopied()
        {
            var inputArray = new int[] { 1, 2, 3, 4, 5 };

            var list = new SingleLinkedList<int>(inputArray);

            Assert.That(list.Count, Is.EqualTo(inputArray.Length));
        }
        #endregion

        #region AddTests;
        [Test]
        public void Add_FirstItemShallBe2_IfAdded2()
        {
            var singleLinkedList = new SingleLinkedList<int>();

            singleLinkedList.Add(2);

            Assert.That(singleLinkedList.PeekFirst(), Is.EqualTo(2));
        }

        [Test]
        public void Add_FirstItemShallBeHello_IfAddedHello()
        {
            var singleLinkedList = new SingleLinkedList<string>();

            singleLinkedList.Add("Hello");

            Assert.That(singleLinkedList.PeekFirst(), Is.EqualTo("Hello"));
        }

        [Test]
        public void Add_ListShallHaveProperCount_IfAddedItemToList()
        {
            var singleLinkedList = new SingleLinkedList<int>() { 1, 2, 3 };

            singleLinkedList.Add(2);

            Assert.That(singleLinkedList.Count(), Is.EqualTo(4));
        }
        #endregion

        #region AddToFrontTests
        public void AddToFront_FirstItemShallBe3_IfAdded3ToFront()
        {
            var singleLinkedList = new SingleLinkedList<int>();

            singleLinkedList.AddToFront(3);

            Assert.That(singleLinkedList.PeekFirst(), Is.EqualTo(3));
        }

        [Test]
        public void AddToFront_FirstItemShallBeWorld_IfAddedWorldToFront()
        {
            var singleLinkedList = new SingleLinkedList<string>();

            singleLinkedList.AddToFront("World");

            Assert.That(singleLinkedList.PeekFirst(), Is.EqualTo("World"));
        }

        [Test]
        public void AddToFront_ListShallHaveProperCount_IfAddedItemToFront()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            singleLinkedList.AddToFront(0);

            Assert.That(singleLinkedList.Count, Is.EqualTo(4));
        }

        [Test]
        public void AddToFront_FirstItemShallBe0_IfAdded0ToFrontAfterAdding1()
        {
            var singleLinkedList = new SingleLinkedList<int>();

            singleLinkedList.Add(1);
            singleLinkedList.AddToFront(0);

            Assert.That(singleLinkedList.PeekFirst(), Is.EqualTo(0));
        }

        [Test]
        public void AddToFront_FirstItemShallBe0_IfAddedToNotEmptyList()
        {
            var singleLinkedList = new SingleLinkedList<int>() { 1, 2, 4 };

            singleLinkedList.AddToFront(0);

            Assert.That(singleLinkedList.PeekFirst(), Is.EqualTo(0));
        }
        #endregion

        #region AddToEndTests
        [Test]
        public void AddToEnd_FirstItemShallBe3_IfAdded3ToEnd()
        {
            var singleLinkedList = new SingleLinkedList<int>();

            singleLinkedList.AddToEnd(3);

            Assert.That(singleLinkedList.PeekLast(), Is.EqualTo(3));
        }

        [Test]
        public void AddToEnd_FirstItemShallBeHello_IfAddedHelloToEnd()
        {
            var singleLinkedList = new SingleLinkedList<string>();

            singleLinkedList.AddToEnd("Hello");

            Assert.That(singleLinkedList.PeekLast(), Is.EqualTo("Hello"));
        }

        [Test]
        public void AddToEnd_ListShallHaveProperCount_IfAddedItemToEnd()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            singleLinkedList.AddToEnd(4);

            Assert.That(singleLinkedList.Count, Is.EqualTo(4));
        }


        [Test]
        public void AddToEnd_FirstItemShallBe0_IfAddedToNotEmptyList()
        {
            var singleLinkedList = new SingleLinkedList<int>() { 1, 2, 3 };

            singleLinkedList.AddToEnd(0);

            Assert.That(singleLinkedList.PeekLast(), Is.EqualTo(0));
        }

        [Test]
        public void AddToEnd_ListShallKeepProperLastItem_IfAddedToEndMultipeTimes()
        {
            var singleLinkedList = new SingleLinkedList<int>() { 1, 2, 3 };

            singleLinkedList.AddToEnd(5);
            singleLinkedList.AddToEnd(3);
            singleLinkedList.AddToEnd(0);

            Assert.That(singleLinkedList.PeekLast(), Is.EqualTo(0));
        }
        #endregion

        #region RemoveTests

        [Test]
        public void Remove_ReturnsFalse_IfListIsEmpty()
        {
            var singleLinkedList = new SingleLinkedList<int>();

            var result = singleLinkedList.Remove(1);

            Assert.That(result, Is.False);
        }

        [Test]
        public void Remove_ReturnsFalse_IfItemNotFound()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            var result = singleLinkedList.Remove(4);

            Assert.That(result, Is.False);
        }

        [Test]
        public void Remove_ReturnsTrue_IfFirstItemIsRemoved()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            var result = singleLinkedList.Remove(1);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Remove_FirstItemShouldBe2_AfterRemovingFirstItem()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            singleLinkedList.Remove(1);

            Assert.That(singleLinkedList.PeekFirst(), Is.EqualTo(2));
        }

        [Test]
        public void Remove_ReturnsTrue_IfLastItemIsRemoved()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            var result = singleLinkedList.Remove(3);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Remove_LastItemShouldBe2_AfterRemovingLastItem()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            singleLinkedList.Remove(3);

            Assert.That(singleLinkedList.PeekLast(), Is.EqualTo(2));
        }

        [Test]
        public void Remove_ReturnsTrue_IfMiddleItemIsRemoved()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            var result = singleLinkedList.Remove(2);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Remove_SecondItemShouldBe3_AfterRemoving2()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3, 4 };

            singleLinkedList.Remove(2);

            Assert.That(singleLinkedList.GetAt(1), Is.EqualTo(3));
        }

        [Test]
        public void Remove_DecreasesCount_IfItemIsRemoved()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            singleLinkedList.Remove(2);

            Assert.That(singleLinkedList.Count, Is.EqualTo(2));
        }

        [Test]
        public void Remove_ReturnsTrue_IfOnlyItemIsRemoved()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1 };

            var result = singleLinkedList.Remove(1);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Remove_CountShouldBeZero_AfterRemovingOnlyItem()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1 };

            singleLinkedList.Remove(1);

            Assert.That(singleLinkedList.Count, Is.EqualTo(0));
        }

        [Test]
        public void Remove_PeekFirstThrowsException_WhenPeekingEmptyList()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1 };

            singleLinkedList.Remove(1);

            Assert.Throws<InvalidOperationException>(() => singleLinkedList.PeekFirst());
        }

        [Test]
        public void Remove_ReturnsTrue_IfFirstStringItemIsRemoved()
        {
            var singleLinkedList = new SingleLinkedList<string> { "Hello", "World" };

            var result = singleLinkedList.Remove("Hello");

            Assert.That(result, Is.True);
        }

        [Test]
        public void Remove_FirstStringItemShouldBeWorld_AfterRemovingFirstStringItem()
        {
            var singleLinkedList = new SingleLinkedList<string> { "Hello", "World" };

            singleLinkedList.Remove("Hello");

            Assert.That(singleLinkedList.PeekFirst(), Is.EqualTo("World"));
        }

        [Test]
        public void Remove_DecreasesCount_IfStringItemIsRemoved()
        {
            var singleLinkedList = new SingleLinkedList<string> { "Hello", "World" };

            singleLinkedList.Remove("Hello");

            Assert.That(singleLinkedList.Count, Is.EqualTo(1));
        }

        #endregion

        #region PopFirstTests;
        [Test]
        public void PopFirst_ThrowsInvalidOperationException_WhenListIsEmpty()
        {
            var singleLinkedList = new SingleLinkedList<int>();

            Assert.Throws<InvalidOperationException>(() => singleLinkedList.PopFirst());
        }

        [Test]
        public void PopFirst_ReturnsFirstItem_WhenListContainsOneItem()
        {
            var singleLinkedList = new SingleLinkedList<int>() { 42 };

            var result = singleLinkedList.PopFirst();

            Assert.That(result, Is.EqualTo(42));
        }

        [Test]
        public void PopFirst_ListCountIsZero_WhenOnlyOneItemIsPopped()
        {
            var singleLinkedList = new SingleLinkedList<int>() { 42 };

            singleLinkedList.PopFirst();

            Assert.That(singleLinkedList.Count, Is.EqualTo(0));
        }

        [Test]
        public void PopFirst_ListCountIs3_When4thItemIsPopped()
        {
            var singleLinkedList = new SingleLinkedList<int>() { 42, 2, 1, 3 };

            singleLinkedList.PopFirst();

            Assert.That(singleLinkedList.Count, Is.EqualTo(3));
        }

        [Test]
        public void PopFirst_ReturnsFirstItem_WhenListContainsMultipleItems()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            var result = singleLinkedList.PopFirst();

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void PopFirst_UpdatesHead_WhenListContainsMultipleItems()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            singleLinkedList.PopFirst();

            Assert.That(singleLinkedList.PeekFirst(), Is.EqualTo(2));
        }

        [Test]
        public void PopFirst_PeekFirstThrowsException_WhenDeletingItemAfterAddingIt()
        {
            var singleLinkedList = new SingleLinkedList<int>();

            singleLinkedList.Add(5);
            singleLinkedList.PopFirst();

            Assert.Throws<InvalidOperationException>(() => singleLinkedList.PeekFirst());
        }

        [Test]
        public void PopFirst_ShallReturnsProperItem_AfterAddingAndRemovingOperations()
        {
            var singleLinkedList = new SingleLinkedList<int>();

            singleLinkedList.Add(5);
            singleLinkedList.AddToFront(3);
            singleLinkedList.Add(6);

            singleLinkedList.PopFirst();

            Assert.That(singleLinkedList.PeekFirst(), Is.EqualTo(5));
        }
        #endregion

        #region PopLastTests
        [Test]
        public void PopLast_ThrowsInvalidOperationException_WhenListIsEmpty()
        {
            var singleLinkedList = new SingleLinkedList<int>();

            Assert.Throws<InvalidOperationException>(() => singleLinkedList.PopLast());
        }

        [Test]
        public void PopLast_ReturnsLastItem_WhenListContainsOneItem()
        {
            var singleLinkedList = new SingleLinkedList<int>() { 42 };

            var result = singleLinkedList.PopLast();

            Assert.That(result, Is.EqualTo(42));
        }

        [Test]
        public void PopLast_ListCountIsZero_WhenOnlyOneItemIsPopped()
        {
            var singleLinkedList = new SingleLinkedList<int>() { 42 };

            singleLinkedList.PopLast();

            Assert.That(singleLinkedList.Count, Is.EqualTo(0));
        }

        [Test]
        public void PopLast_ListCountIs3_When4thItemIsPopped()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3, 4 };

            singleLinkedList.PopLast();

            Assert.That(singleLinkedList.Count, Is.EqualTo(3));
        }

        [Test]
        public void PopLast_ReturnsLastItem_WhenListContainsMultipleItems()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            var result = singleLinkedList.PopLast();

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void PopLast_UpdatesTail_WhenListContainsMultipleItems()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            singleLinkedList.PopLast();

            Assert.That(singleLinkedList.PeekLast(), Is.EqualTo(2));
        }

        [Test]
        public void PopLast_PeekLastThrowsException_WhenDeletingItemAfterAddingIt()
        {
            var singleLinkedList = new SingleLinkedList<int>();

            singleLinkedList.Add(5);
            singleLinkedList.PopLast();

            Assert.Throws<InvalidOperationException>(() => singleLinkedList.PeekLast());
        }

        [Test]
        public void PopLast_ShallReturnsProperItem_AfterAddingAndRemovingOperations()
        {
            var singleLinkedList = new SingleLinkedList<int>();

            singleLinkedList.Add(5);
            singleLinkedList.Add(3);
            singleLinkedList.Add(6);

            singleLinkedList.PopLast();

            Assert.That(singleLinkedList.PeekLast(), Is.EqualTo(3));
        }

        #endregion

        #region PeekFirstTests

        [Test]
        public void PeekFirst_ThrowsInvalidOperationException_WhenListIsEmpty()
        {
            var singleLinkedList = new SingleLinkedList<int>();

            Assert.Throws<InvalidOperationException>(() => singleLinkedList.PeekFirst());
        }

        [Test]
        public void PeekFirst_ReturnsFirstItem_WhenListContainsOneItem()
        {
            var singleLinkedList = new SingleLinkedList<int>() { 42 };

            var result = singleLinkedList.PeekFirst();

            Assert.That(result, Is.EqualTo(42));
        }

        [Test]
        public void PeekFirst_ReturnsFirstItem_WhenListContainsMultipleItems()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            var result = singleLinkedList.PeekFirst();

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void PeekFirst_CountIsUnchanged_WhenCalled()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            singleLinkedList.PeekFirst();

            Assert.That(singleLinkedList.Count, Is.EqualTo(3));
        }

        [Test]
        public void PeekFirst_ReturnsFirstItem_WhenListContainsStrings()
        {
            var singleLinkedList = new SingleLinkedList<string> { "Hello", "World" };

            var result = singleLinkedList.PeekFirst();

            Assert.That(result, Is.EqualTo("Hello"));
        }

        [Test]
        public void PeekFirst_DoesNotAffectList_WhenCalledMultipleTimes()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            var firstItem1 = singleLinkedList.PeekFirst();
            var firstItem2 = singleLinkedList.PeekFirst();

            Assert.That(firstItem1, Is.EqualTo(1));
            Assert.That(firstItem2, Is.EqualTo(1));
        }

        #endregion

        #region PeekLastTests

        [Test]
        public void PeekLast_ThrowsInvalidOperationException_WhenListIsEmpty()
        {
            var singleLinkedList = new SingleLinkedList<int>();

            Assert.Throws<InvalidOperationException>(() => singleLinkedList.PeekLast());
        }

        [Test]
        public void PeekLast_ReturnsLastItem_WhenListContainsOneItem()
        {
            var singleLinkedList = new SingleLinkedList<int>() { 42 };

            var result = singleLinkedList.PeekLast();

            Assert.That(result, Is.EqualTo(42));
        }

        [Test]
        public void PeekLast_ReturnsLastItem_WhenListContainsMultipleItems()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            var result = singleLinkedList.PeekLast();

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void PeekLast_CountIsUnchanged_WhenCalled()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            singleLinkedList.PeekLast();

            Assert.That(singleLinkedList.Count, Is.EqualTo(3));
        }

        [Test]
        public void PeekLast_ReturnsLastItem_WhenListContainsStrings()
        {
            var singleLinkedList = new SingleLinkedList<string> { "Hello", "World" };

            var result = singleLinkedList.PeekLast();

            Assert.That(result, Is.EqualTo("World"));
        }

        [Test]
        public void PeekLast_DoesNotAffectList_WhenCalledMultipleTimes()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            var lastItem1 = singleLinkedList.PeekLast();
            var lastItem2 = singleLinkedList.PeekLast();

            Assert.That(lastItem1, Is.EqualTo(3));
            Assert.That(lastItem2, Is.EqualTo(3));
        }

        #endregion

        #region GetAtTests

        [Test]
        public void GetAt_ThrowsArgumentOutOfRangeException_WhenIndexIsNegative()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            Assert.Throws<ArgumentOutOfRangeException>(() => singleLinkedList.GetAt(-1));
        }

        [Test]
        public void GetAt_ThrowsArgumentOutOfRangeException_WhenIndexIsOutOfRange()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            Assert.Throws<ArgumentOutOfRangeException>(() => singleLinkedList.GetAt(3));
        }

        [Test]
        public void GetAt_ReturnsCorrectItem_WhenIndexIsValid()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            var result = singleLinkedList.GetAt(1);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void GetAt_ReturnsFirstItem_WhenIndexIsZero()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            var result = singleLinkedList.GetAt(0);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void GetAt_ReturnsLastItem_WhenIndexIsCountMinusOne()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            var result = singleLinkedList.GetAt(2);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void GetAt_ReturnsCorrectItem_WhenListContainsStrings()
        {
            var singleLinkedList = new SingleLinkedList<string> { "Hello", "World" };

            var result = singleLinkedList.GetAt(1);

            Assert.That(result, Is.EqualTo("World"));
        }

        #endregion

        #region MergeTests

        [Test]
        public void Merge_ThrowsArgumentNullException_WhenListIsNull()
        {
            var list1 = new SingleLinkedList<int> { 1, 2, 3 };
            SingleLinkedList<int> list2 = null!;

            Assert.Throws<ArgumentNullException>(() => list1.Merge(list2));
        }

        [Test]
        public void Merge_ItemsInMergedListAreCorrect_WhenMeged()
        {
            var list1 = new SingleLinkedList<int> { 1, 2, 3 };
            var list2 = new SingleLinkedList<int> { 4, 5, 6 };

            list1.Merge(list2);

            var expectedItems = new List<int> { 1, 2, 3, 4, 5, 6 };
            for (int i = 0; i < expectedItems.Count; i++)
            {
                Assert.That(list1.GetAt(i), Is.EqualTo(expectedItems[i]));
            }
        }

        [Test]
        public void Merge_CountStaysTheSame_WhenListToMergeIsEmpty()
        {
            var list1 = new SingleLinkedList<int> { 1, 2, 3 };
            var list2 = new SingleLinkedList<int>();

            list1.Merge(list2);

            Assert.That(list1.Count, Is.EqualTo(3));
        }

        [Test]
        public void Merge_ItemsRemainSame_WhenSecondListIsEmpty()
        {
            var list1 = new SingleLinkedList<int> { 1, 2, 3 };
            var list2 = new SingleLinkedList<int>();

            list1.Merge(list2);

            Assert.That(list1.GetAt(0), Is.EqualTo(1));
            Assert.That(list1.GetAt(1), Is.EqualTo(2));
            Assert.That(list1.GetAt(2), Is.EqualTo(3));
        }

        [Test]
        public void Merge_MergesSingleElementListIntoNonEmptyList()
        {
            var list1 = new SingleLinkedList<int> { 1, 2, 3 };
            var list2 = new SingleLinkedList<int> { 4 };

            list1.Merge(list2);

            Assert.That(list1.Count, Is.EqualTo(4));
        }

        [Test]
        public void Merge_FirstItemShouldRemainTheSame_WhenMergingSingleElementList()
        {
            var list1 = new SingleLinkedList<int> { 1, 2, 3 };
            var list2 = new SingleLinkedList<int> { 4 };

            list1.Merge(list2);

            Assert.That(list1.PeekFirst(), Is.EqualTo(1));
        }

        [Test]
        public void Merge_LastItemShouldBeLastOfMergedList_WhenMergingMultipleItems()
        {
            var list1 = new SingleLinkedList<int> { 1, 2 };
            var list2 = new SingleLinkedList<int> { 3, 4, 5 };

            list1.Merge(list2);

            Assert.That(list1.PeekLast(), Is.EqualTo(5));
        }

        [Test]
        public void Merge_MergesProperlyIntoEmptyList_AfterMerge()
        {
            var list1 = new SingleLinkedList<int>();
            var list2 = new SingleLinkedList<int> { 1, 2, 3 };

            list1.Merge(list2);

            Assert.That(list1.Count, Is.EqualTo(3));
        }

        [Test]
        public void Merge_FirstItemShouldBeFirstOfMergedList_WhenMergingMultipleItems()
        {
            var list1 = new SingleLinkedList<int>();
            var list2 = new SingleLinkedList<int> { 1, 2, 3 };

            list1.Merge(list2);

            Assert.That(list1.PeekFirst(), Is.EqualTo(1));
        }

        [Test]
        public void Merge_ListToMergeIsCleared_AfterMErge()
        {
            var list1 = new SingleLinkedList<int> { 1, 2, 3 };
            var list2 = new SingleLinkedList<int> { 4, 5, 6 };

            list1.Merge(list2);

            Assert.That(list2.Count, Is.EqualTo(0));
        }

        #endregion

        #region ClearTests
        [Test]
        public void Clear_SetsCountToZero_AfterClearingList()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            singleLinkedList.Clear();

            Assert.That(singleLinkedList.Count, Is.EqualTo(0));
        }

        [Test]
        public void Clear_SetsHeadToNull_AfterClearingList()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            singleLinkedList.Clear();

            Assert.Throws<InvalidOperationException>(() => singleLinkedList.PeekFirst());
        }
        public void Clear_SetsTailToNull_AfterClearingList()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            singleLinkedList.Clear();

            Assert.Throws<InvalidOperationException>(() => singleLinkedList.PeekLast());
        }


        [Test]
        public void Clear_EmptyList_AfterClearingAnAlreadyEmptyList()
        {
            var singleLinkedList = new SingleLinkedList<int>();

            singleLinkedList.Clear();

            Assert.That(singleLinkedList.Count, Is.EqualTo(0));
        }
        #endregion

        #region ContainsTests;
        [Test]
        public void Contains_ReturnsFalse_WhenListIsEmpty()
        {
            var singleLinkedList = new SingleLinkedList<int>();

            var result = singleLinkedList.Contains(5);

            Assert.That(result, Is.False);
        }

        [Test]
        public void Contains_ReturnsTrue_WhenItemExistsInList()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            var result = singleLinkedList.Contains(2);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Contains_ReturnsFalse_WhenItemDoesNotExistInList()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            var result = singleLinkedList.Contains(4);

            Assert.That(result, Is.False);
        }

        [Test]
        public void Contains_ReturnsTrue_WhenCheckingForItemWhichIsFirstInCollection()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            var result = singleLinkedList.Contains(1);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Contains_ReturnsTrue_WhenCheckingForItemWhichIsLastInCollection()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            var result = singleLinkedList.Contains(3);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Contains_ReturnsTrue_WhenListContainsDuplicateItems()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 2, 3 };

            var result = singleLinkedList.Contains(2);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Contains_ReturnsTrue_WhenCheckingForNullInNullableList()
        {
            var singleLinkedList = new SingleLinkedList<int?> { 1, 2, null, 3 };

            var result = singleLinkedList.Contains(null);

            Assert.That(result, Is.True);
        }
        #endregion

        #region CopyToTests
        [Test]
        public void CopyTo_ThrowsArgumentNullException_WhenArrayIsNull()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            Assert.Throws<ArgumentNullException>(() => singleLinkedList.CopyTo(null, 0));
        }

        [Test]
        public void CopyTo_ThrowsArgumentOutOfRangeException_WhenArrayIndexIsNegative()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            Assert.Throws<ArgumentOutOfRangeException>(() => singleLinkedList.CopyTo(new int[3], -1));
        }

        [Test]
        public void CopyTo_ThrowsArgumentException_WhenInsufficientSpaceInArray()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };

            Assert.Throws<ArgumentException>(() => singleLinkedList.CopyTo(new int[2], 0));
        }

        [Test]
        public void CopyTo_CopiesItemsToArray_WhenArrayHasSufficientSpace()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };
            var array = new int[5];

            singleLinkedList.CopyTo(array, 1);

            Assert.That(array[1], Is.EqualTo(1));
            Assert.That(array[2], Is.EqualTo(2));
            Assert.That(array[3], Is.EqualTo(3));
        }

        [Test]
        public void CopyTo_CopiesItemsToArray_WhenStartingAtArrayIndexZero()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };
            var array = new int[3];

            singleLinkedList.CopyTo(array, 0);

            Assert.That(array[0], Is.EqualTo(1));
            Assert.That(array[1], Is.EqualTo(2));
            Assert.That(array[2], Is.EqualTo(3));
        }

        [Test]
        public void CopyTo_DoesNotOverwriteArrayItems_WhenArrayIndexIsGreaterThanZero()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };
            var array = new int[5] { 0, 0, 0, 0, 0 };

            singleLinkedList.CopyTo(array, 2);

            Assert.That(array[0], Is.EqualTo(0));
            Assert.That(array[1], Is.EqualTo(0));
            Assert.That(array[2], Is.EqualTo(1));
            Assert.That(array[3], Is.EqualTo(2));
            Assert.That(array[4], Is.EqualTo(3));
        }

        [Test]
        public void CopyTo_CopiesItemsCorrectly_WhenListContainsNullables()
        {
            var singleLinkedList = new SingleLinkedList<int?> { 1, null, 3 };
            var array = new int?[3];

            singleLinkedList.CopyTo(array, 0);

            Assert.That(array[0], Is.EqualTo(1));
            Assert.That(array[1], Is.Null);
            Assert.That(array[2], Is.EqualTo(3));
        }
        #endregion

        #region GetEnumeratorTests;
        [Test]
        public void GetEnumerator_ReturnsItemsInOrder_WhenListContainsMultipleItems()
        {
            var singleLinkedList = new SingleLinkedList<int> { 1, 2, 3 };
            var enumeratedItems = new List<int>();

            foreach (var item in singleLinkedList)
            {
                enumeratedItems.Add(item);
            }

            Assert.That(enumeratedItems, Is.EqualTo(new List<int> { 1, 2, 3 }));
        }

        [Test]
        public void GetEnumerator_ReturnsSingleItem_WhenListContainsOneItem()
        {
            var singleLinkedList = new SingleLinkedList<int> { 42 };
            var enumeratedItems = new List<int>();

            foreach (var item in singleLinkedList)
            {
                enumeratedItems.Add(item);
            }

            Assert.That(enumeratedItems, Is.EqualTo(new List<int> { 42 }));
        }

        [Test]
        public void GetEnumerator_ReturnsNoItems_WhenListIsEmpty()
        {
            var singleLinkedList = new SingleLinkedList<int>();
            var enumeratedItems = new List<int>();

            foreach (var item in singleLinkedList)
            {
                enumeratedItems.Add(item);
            }

            Assert.That(enumeratedItems, Is.Empty);
        }

        [Test]
        public void GetEnumerator_EnumeratesCorrectly_WhenListContainsNullables()
        {
            var singleLinkedList = new SingleLinkedList<int?> { 1, null, 3 };
            var enumeratedItems = new List<int?>();

            foreach (var item in singleLinkedList)
            {
                enumeratedItems.Add(item);
            }

            Assert.That(enumeratedItems, Is.EqualTo(new List<int?> { 1, null, 3 }));
        }
        #endregion
    }
}