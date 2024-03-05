CREATE PROCEDURE [dbo].[spRoomTypes_GetAvailableTypes]
	@startDate date,
	@endDate date
AS
begin
	set nocount on;

	SELECT t.Id, t.Title, t.Description, t.Price
	FROM dbo.Rooms r
	inner join dbo.RoomTypes t on t.Id = r.RoomTypeId
	where r.Id not in(
	select b.RoomId
	from dbo.Bookings b
	where (@startDate < b.StartDate and @endDate > b.EndDate)
		or (b.StartDate <= @endDate and @endDate < b.EndDate)
		or (b.StartDate <= @startDate and @startDate < b.EndDate)
	) 
	group by t.Id, t.Title, t.Description, t.Price
end