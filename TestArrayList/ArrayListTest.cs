using Xunit;
using System;
using ArrayList;
using Students;

public class ArrayListTest
{
    [Fact]
    public void givenNewList_whenSize_thenZeroIsReturned()
    {
        // Given:
        ArrayList<Student> arrayList = new ArrayList<Student>();

        // When:
        int size = arrayList.size();

        // Then:
        Assert.Equal(0, size);
    }

    [Fact]
    public void givenNewList_whenAdd_thenElementIsInserted()
    {
        // Given:
        ArrayList<Student> arrayList = new ArrayList<Student>();
        Student student = new Student("Ivan");

        // When:
        arrayList.add(student);

        // Then:
        Assert.Equal(1, arrayList.size());
        Assert.Equal(arrayList.getAt(0).getName(), "Ivan");
    }

    [Fact]
    public void givenAListWithNoMoreCapacity_whenAdd_thenElementIsInserted()
    {
        // Given:
        ArrayList<Student> arrayList = new ArrayList<Student>(2);

        arrayList.add(new Student("Ivan"));
        arrayList.add(new Student("Israel"));


        // When:
        arrayList.add(new Student("Francisco"));

        // Then:
        Assert.Equal(3, arrayList.size());
        Assert.Equal(arrayList.getAt(0).getName(), "Ivan");
        Assert.Equal(arrayList.getAt(1).getName(), "Israel");
        Assert.Equal(arrayList.getAt(2).getName(), "Francisco");
    }

    [Fact]
    public void givenAListWith3Elements_whenDeleteReferenceStudentFist_thenElementsDeleted()
    {
        // Given:
        ArrayList<Student> arrayList = new ArrayList<Student>();
        Student reference = new Student("Ivan");
        try
        {
            arrayList.add(reference);
            arrayList.add(new Student("Israel"));
            arrayList.add(new Student("Francisco"));

            // When:
            arrayList.delete(reference);
        }
        catch (IndexOutOfRangeException) { }
        //Then:
        Assert.Equal(2, arrayList.size());
        Assert.Equal(arrayList.getAt(0).getName(), "Israel");
        Assert.Equal(arrayList.getAt(1).getName(), "Francisco");
    }
    [Fact]
    public void givenAListWith3Elements_whenDeleteReferenceStudentMiddle_thenElementsDeleted()
    {
        // Given:
        ArrayList<Student> arrayList = new ArrayList<Student>();
        Student reference = new Student("Israel");
        try
        {
            arrayList.add(new Student("Ivan"));
            arrayList.add(reference);
            arrayList.add(new Student("Francisco"));
            // When:
            arrayList.delete(reference);
        }
        catch (IndexOutOfRangeException) { }
        //Then:
        Assert.Equal(2, arrayList.size());
        Assert.Equal(arrayList.getAt(0).getName(), "Ivan");
        Assert.Equal(arrayList.getAt(1).getName(), "Francisco");
    }

    [Fact]

    public void givenAListWith3Elements_whenDeleteReferenceStudentEnd_thenElementsDeleted()
    {
        // Given:
        ArrayList<Student> arrayList = new ArrayList<Student>();
        Student reference = new Student("Francisco");
        try
        {
            arrayList.add(new Student("Ivan"));
            arrayList.add(new Student("Israel"));
            arrayList.add(reference);

            // When:
            arrayList.delete(reference);
        }
        catch (IndexOutOfRangeException) { }
        //Then:
        Assert.Equal(2, arrayList.size());
        Assert.Equal(arrayList.getAt(0).getName(), "Ivan");
        Assert.Equal(arrayList.getAt(1).getName(), "Israel");
    }

    [Fact]
    public void givenAListWith3Elements_whenDeleteFirst_thenElementIsDeleted()
    {
        // Given:
        ArrayList<Student> arrayList = new ArrayList<Student>();
        try
        {


            arrayList.add(new Student("Ivan"));
            arrayList.add(new Student("Israel"));
            arrayList.add(new Student("Francisco"));

            // When:
            arrayList.delete(0);
        }
        catch (IndexOutOfRangeException) { }
        // Then:
        Assert.Equal(2, arrayList.size());
        Assert.Equal(arrayList.getAt(0).getName(), "Israel");
        Assert.Equal(arrayList.getAt(1).getName(), "Francisco");
    }

    [Fact]
    public void givenAListWith3Elements_whenDeleteLast_thenElementIsDeleted()
    {
        // Given:
        ArrayList<Student> arrayList = new ArrayList<Student>();
        try
        {
            arrayList.add(new Student("Ivan"));
            arrayList.add(new Student("Israel"));
            arrayList.add(new Student("Francisco"));

            // When:
            arrayList.delete(2);
        }
        catch (IndexOutOfRangeException) { }


        // Then:
        Assert.Equal(2, arrayList.size());
        Assert.Equal(arrayList.getAt(0).getName(), "Ivan");
        Assert.Equal(arrayList.getAt(1).getName(), "Israel");

    }

    [Fact]
    public void givenAListWith3Elements_whenDeleteMiddle_thenElementIsDeleted()
    {
        // Given:
        ArrayList<Student> arrayList = new ArrayList<Student>();
        try
        {
            arrayList.add(new Student("Ivan"));
            arrayList.add(new Student("Israel"));
            arrayList.add(new Student("Francisco"));

            // When:
            arrayList.delete(1);
        }
        catch (IndexOutOfRangeException) { }
        // Then:
        Assert.Equal(2, arrayList.size());
        Assert.Equal(arrayList.getAt(0).getName(), "Ivan");
        Assert.Equal(arrayList.getAt(1).getName(), "Francisco");
    }
    [Fact]
    public void givenAListWith3Elements_whenDeleteNegative_thenDoesNothing()
    {
        // Given:
        ArrayList<Student> arrayList = new ArrayList<Student>();
        try
        {
            arrayList.add(new Student("Ivan"));
            arrayList.add(new Student("Israel"));
            arrayList.add(new Student("Francisco"));

            // When:
            arrayList.delete(-1);
        }
        catch (IndexOutOfRangeException) { }
        // Then:
        Assert.Equal(3, arrayList.size());
        Assert.Equal(arrayList.getAt(0).getName(), "Ivan");
        Assert.Equal(arrayList.getAt(1).getName(), "Israel");
        Assert.Equal(arrayList.getAt(2).getName(), "Francisco");
        Assert.Throws<IndexOutOfRangeException>(() => arrayList.delete(-1));
    }

    [Fact]
    public void givenAListWith3Elements_whenDeleteOutOfSize_thenDoesNothing()
    {
        // Given:
        ArrayList<Student> arrayList = new ArrayList<Student>();
        try
        {
            arrayList.add(new Student("Ivan"));
            arrayList.add(new Student("Israel"));
            arrayList.add(new Student("Francisco"));

            // When:
            arrayList.delete(4);
        }
        catch (IndexOutOfRangeException) { }


        // Then:
        Assert.Equal(3, arrayList.size());
        Assert.Equal(arrayList.getAt(0).getName(), "Ivan");
        Assert.Equal(arrayList.getAt(1).getName(), "Israel");
        Assert.Equal(arrayList.getAt(2).getName(), "Francisco");
    }

    [Fact]
    public void givenAListWith3Elements_whenInsertAtBeginningBefore_thenElementIsInserted()
    {
        // Given:
        ArrayList<Student> arrayList = new ArrayList<Student>();
        Student reference = new Student("Ivan");

        arrayList.add(reference);
        arrayList.add(new Student("Israel"));
        arrayList.add(new Student("Francisco"));

        // When:
        arrayList.insert(reference, new Student("Lupita"), ArrayList<Student>.InsertPosition.BEFORE);

        // Then:
        Assert.Equal(4, arrayList.size());
        Assert.Equal(arrayList.getAt(0).getName(), "Lupita");
        Assert.Equal(arrayList.getAt(1).getName(), "Ivan");
        Assert.Equal(arrayList.getAt(2).getName(), "Israel");
        Assert.Equal(arrayList.getAt(3).getName(), "Francisco");
    }

    [Fact]
    public void givenAListWith3Elements_whenInsertAtBeginningBefore_thenElementIsInsertedIncorrectReference()
    {
        // Given:
        ArrayList<Student> arrayList = new ArrayList<Student>();
        Student reference = new Student("Ivan");
        try
        {
            arrayList.add(new Student("Edilberto"));
            arrayList.add(new Student("Israel"));
            arrayList.add(new Student("Francisco"));

            // When:
            arrayList.insert(reference, new Student("Lupita"), ArrayList<Student>.InsertPosition.BEFORE);
        }
        catch (NullReferenceException) { }


        // Then:
        Assert.Equal(3, arrayList.size());
        Assert.Equal(arrayList.getAt(0).getName(), "Edilberto");
        Assert.Equal(arrayList.getAt(1).getName(), "Israel");
        Assert.Equal(arrayList.getAt(2).getName(), "Francisco");
        Assert.Throws<NullReferenceException>(() => arrayList.insert(reference, new Student("Lupita"), ArrayList<Student>.InsertPosition.BEFORE));
    }

    [Fact]
    public void givenAListWith3Elements_whenInsertAtEndBefore_thenElementIsInserted()
    {
        // Given:
        ArrayList<Student> arrayList = new ArrayList<Student>();
        Student reference = new Student("Francisco");

        arrayList.add(new Student("Ivan"));
        arrayList.add(new Student("Israel"));
        arrayList.add(reference);

        // When:
        arrayList.insert(reference, new Student("Lupita"), ArrayList<Student>.InsertPosition.BEFORE);

        // Then:
        Assert.Equal(4, arrayList.size());
        Assert.Equal(arrayList.getAt(0).getName(), "Ivan");
        Assert.Equal(arrayList.getAt(1).getName(), "Israel");
        Assert.Equal(arrayList.getAt(2).getName(), "Lupita");
        Assert.Equal(arrayList.getAt(3).getName(), "Francisco");
    }

    [Fact]
    public void givenAListWith3Elements_whenInsertAtMiddleBefore_thenElementIsInserted()
    {
        // Given:
        ArrayList<Student> arrayList = new ArrayList<Student>();
        Student reference = new Student("Israel");

        arrayList.add(new Student("Ivan"));
        arrayList.add(reference);
        arrayList.add(new Student("Francisco"));

        // When:
        arrayList.insert(reference, new Student("Lupita"), ArrayList<Student>.InsertPosition.BEFORE);

        // Then:
        Assert.Equal(4, arrayList.size());
        Assert.Equal(arrayList.getAt(0).getName(), "Ivan");
        Assert.Equal(arrayList.getAt(1).getName(), "Lupita");
        Assert.Equal(arrayList.getAt(2).getName(), "Israel");
        Assert.Equal(arrayList.getAt(3).getName(), "Francisco");
    }

    [Fact]
    public void givenAListWith3Elements_whenInsertAtBeginningAfter_thenElementIsInserted()
    {
        // Given:
        ArrayList<Student> arrayList = new ArrayList<Student>();
        Student reference = new Student("Ivan");

        arrayList.add(reference);
        arrayList.add(new Student("Israel"));
        arrayList.add(new Student("Francisco"));

        // When:
        arrayList.insert(reference, new Student("Lupita"), ArrayList<Student>.InsertPosition.AFTER);

        // Then:
        Assert.Equal(4, arrayList.size());
        Assert.Equal(arrayList.getAt(0).getName(), "Ivan");
        Assert.Equal(arrayList.getAt(1).getName(), "Lupita");
        Assert.Equal(arrayList.getAt(2).getName(), "Israel");
        Assert.Equal(arrayList.getAt(3).getName(), "Francisco");
    }

    [Fact]
    public void givenAListWith3Elements_whenInsertAtEndAfter_thenElementIsInserted()
    {
        // Given:
        ArrayList<Student> arrayList = new ArrayList<Student>();
        Student reference = new Student("Francisco");

        arrayList.add(new Student("Ivan"));
        arrayList.add(new Student("Israel"));
        arrayList.add(reference);

        // When:
        arrayList.insert(reference, new Student("Lupita"), ArrayList<Student>.InsertPosition.AFTER);

        // Then:
        Assert.Equal(4, arrayList.size());
        Assert.Equal(arrayList.getAt(0).getName(), "Ivan");
        Assert.Equal(arrayList.getAt(1).getName(), "Israel");
        Assert.Equal(arrayList.getAt(2).getName(), "Francisco");
        Assert.Equal(arrayList.getAt(3).getName(), "Lupita");
    }

    [Fact]
    public void givenAListWith3Elements_whenInsertAtMiddleAfter_thenElementIsInserted()
    {
        // Given:
        ArrayList<Student> arrayList = new ArrayList<Student>();
        Student reference = new Student("Israel");

        arrayList.add(new Student("Ivan"));
        arrayList.add(reference);
        arrayList.add(new Student("Francisco"));

        // When:
        arrayList.insert(reference, new Student("Lupita"), ArrayList<Student>.InsertPosition.AFTER);

        // Then:
        Assert.Equal(4, arrayList.size());
        Assert.Equal(arrayList.getAt(0).getName(), "Ivan");
        Assert.Equal(arrayList.getAt(1).getName(), "Israel");
        Assert.Equal(arrayList.getAt(2).getName(), "Lupita");
        Assert.Equal(arrayList.getAt(3).getName(), "Francisco");
    }

    [Fact]
    public void givenEmptyList_whenGetIterator_thenIteratorIsEmpty()
    {
        // Given:
        ArrayList<Student> arrayList = new ArrayList<Student>();

        // When:
        ArrayList<Student>.Iterator iterator = arrayList.getIterator();

        // Then:
        Assert.NotNull(iterator);
        Assert.False(iterator.hasNext());
        Assert.Null(iterator.next());
    }

    [Fact]
    public void givenListWithOneElement_whenGetIterator_thenIteratorHasOneNext()
    {
        // Given:
        ArrayList<Student> arrayList = new ArrayList<Student>();

        arrayList.add(new Student("Ivan"));

        // When:
        ArrayList<Student>.Iterator iterator = arrayList.getIterator();

        // Then:
        Assert.NotNull(iterator);
        Assert.True(iterator.hasNext());
        Student student = iterator.next();
        Assert.NotNull(student);
        Assert.Equal("Ivan", student.getName());
        Assert.False(iterator.hasNext());
        Assert.Null(iterator.next());
    }

}