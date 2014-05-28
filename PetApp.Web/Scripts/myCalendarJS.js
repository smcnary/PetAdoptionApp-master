$.getJSON("/api/Schedules", function (data) {
    formatEvent(data);
});

var setUpCalendar = function (data) {
    $('#calendar').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },

        editable: false,

        events: data,

        eventDrop: function (event, delta) {
            alert(event.title + ' was moved ' + delta + ' days\n' +
                '(should probably update your database)');
        },

        loading: function (bool) {
            if (bool) $('#loading').show();
            else $('#loading').hide();
        }

    });
}

var formatEvent = function (data) {
    events = [];
    console.log(data);
    for (var x = 0; x < data.length; x++)
    {
        var person  = data[x].Volunteer.FirstName
        var pet     = data[x].Pet.Name;
       
        //StartTime
        var datetime = data[x].StartTime.split("T");
        var split = datetime[0].split("-");
        var time = datetime[1];

        var hour = parseInt(time.split(":")[0]);
        var minute = parseInt(time.split(":")[1]);

        var month   = parseInt(split[1]) - 1;  //Month is 0 based
        var year    = parseInt(split[0]);
        var day     = parseInt(split[2]);

        //EndTime
        var endtime = data[x].EndTime.split("T");
        var split2 = endtime[0].split("-");
        var time2 = endtime[1];

        var hour2 = parseInt(time2.split(":")[0]);
        var minute2 = parseInt(time2.split(":")[1]);

        var month2   = parseInt(split2[1]) - 1;  //Month is 0 based
        var year2    = parseInt(split2[0]);
        var day2     = parseInt(split2[2]);
        

        var event = { title: person + " is walking " + pet, start: new Date(year, month, day, hour, minute), end: new Date(year2, month2, day2, hour2, minute2), allDay: false }
        events.push(event);
    }
    console.log(events);
    setUpCalendar(events);
};