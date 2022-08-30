import "fullcalendar";

$(document).ready(function () {
    InitializeCalendar();
});

function InitializeCalendar() {
    try {

        var calendarEl = document.getElementById('calendar');
        if (calendarEl != null) {
            var calendar = new FullCalendar.Calendar(calendarEl, {
                initialView: 'dayGridMonth',
                headerToolbar: {
                    left: 'prev,next,today',
                    center: 'title',
                    right: 'dayGridMonth,dayGridWeek,dayGridDay'
                    },
                    selectable: true,
                    editable: false,
                    select: function (event) {
                        onShowModel(event, null);
                    }
                });
                calendar.render();
        }
    }
    catch (e) {
        alert(e);
    }
}


function onShowModel(obj, isEventDetail) {
    $("#appointmentInput").modal("show");
}

function onCloseModel() {
    $("#appointmentInput").modal("hide");
}