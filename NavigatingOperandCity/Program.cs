//The challenge also called for another + operator overload for BlockCoordinate and Direction, however I got ahead of myself a little bit
//and created an implicit cast operator for Direction to BlockOffset which made the operator redundant so I skipped it. 
//Does that technically mean I didn't 100% this? i'm ruling no.

public record BlockCoordinate (int Row, int Column) 
{
    //Answer to challenge question: the indexer does not provide many benefits in this specific use case, there are only two properties
    //and the indexer is not immediately clear what each int is supposed to represent without looking at the implementation of the indexer
    public int this[int index] => index switch
    {
        0 => Row,
        1 => Column,
        _ => throw new IndexOutOfRangeException(),
    };

    public static BlockCoordinate operator +(BlockCoordinate a, BlockOffset b) => new (a.Row + b.RowOffset, a.Column + b.ColumnOffset);
}
public record BlockOffset (int RowOffset, int ColumnOffset) 
{
    //Answer to challenge question: I went with an implicit cast operator for Direction to BlockOffset because no information is lost during the cast
    //it is also immediately clear what each direction will be cast to, this also has the added benefit of only needing the one + operator overload
    //for the BlockCoordinate record as explained above
    public static implicit operator BlockOffset (Direction dir) => dir switch
    {
        Direction.West => new(0, -1),
        Direction.East => new(0, 1),
        Direction.North => new(-1, 0),
        Direction.South => new(1, 0),
        _ => throw new NotImplementedException(),
    };
}
public enum Direction { North, East, South, West }