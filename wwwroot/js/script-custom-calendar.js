﻿var routeURL = location.protocol + "//" + location.host;
$(document).ready(function () {
    $("#appointmentDate").kendoDateTimePicker({
        value: new Date(),
        dateInput: false
    });

    InitializeCalendar();
});
var calendar;
function InitializeCalendar() {
    try {
        var calendarEl = document.getElementById('calendar');
        if (calendarEl != null) {
            calendar = new FullCalendar.Calendar(calendarEl, {
             //   eventLimit: true,
                initialView: 'dayGridMonth',
                headerToolbar: {
                    left: 'prev,next,today',
                    center: 'title',
                    right: 'dayGridMonth,timeGridWeek,timeGridDay'
                    //views: {
                    //    timeGridDay: {
                    //        dayMaxEventRows: 5,
                    //        eventLimit: 2
                    //    }
                    //},
                },
                selectable: true,
                editable: false,
                select: function (event) {
                    onShowModal(event, null);
                },
                eventDisplay: 'block',
                events: function (fetchInfo, successCallback, failureCallback) {
                    $.ajax({
                        url: routeURL + '/api/Appointment/GetCalendarData?teacherId=' + $("#teacherId").val(),
                        type: 'GET',
                        dataType: 'JSON',
                        success: function (response) {
                            var events = [];
                            if (response.status === 1) {
                                $.each(response.dataenum, function (i, data) {
                                    events.push({
                                        title: data.title,
                                        //description: data.description,
                                        start: data.startDate,
                                        end: data.endDate,
                                        backgroundColor: data.isTeacherApproved ? "#28a745" : "#dc3545",
                                        borderColor: "#162466",
                                        textColor: "white",
                                        id: data.id
                                    });
                                })
                            }
                            successCallback(events);
                        },
                        error: function (xhr) {
                            $.notify("Error", "error");
                        }
                    });
                },
                eventClick: function (info) {
                    getEventDetailsByEventId(info.event);
                }
            });
            calendar.render();
        }
    }
    catch (e) {
        alert(e);
    }
}
function onShowModal(obj, isEventDetail) {
    if (isEventDetail != null) {
        $("#title").val(obj.title);
        $("#appointmentDate").val(obj.startDate);
        $("#duration").val(obj.duration);
        $("#teacherId").val(obj.teacherId);
        $("#studentId").val(obj.studentId);
        $("#styleId").val(obj.styleId);
        $("#classTypeId").val(obj.classTypeId);
        $("#id").val(obj.id);
        $("#lblStudentName").html(obj.StudentName);
        $("#lblTeacherName").html(obj.TeacherName);
        if (obj.isTeacherApproved) {
            $("#lblStatus").html('Approved');
            $("#btnConfirm").addClass("d-none");
            $("#btnSubmit").addClass("d-none");
        }
        else {
            $("#lblStatus").html('Pending');
            $("#btnConfirm").removeClass("d-none");
            $("#btnSubmit").removeClass("d-none");
        }
        $("#btnDelete").removeClass("d-none");
    }
    else {
        $("#appointmentDate").val(obj.startStr + " " + new moment().format("hh:mm A"));
        $("#id").val(0);
        $("#btnDelete").addClass("d-none");
        $("#btnSubmit").removeClass("d-none");
    }
    $("#appointmentInput").modal("show");
}

function onCloseModal() {
    $("#apointmentForm")[0].reset();
    $("#id").val(0);
    $("#title").val('');
    $("#appointmentDate").val('');
    $("#duration").val('');
    $("#studentId").val('');
    $("#styleId").val('');
    $("#classTypeId").val('');
    $("#appointmentInput").modal("hide");
}

function onSubmitForm() {
    if (checkValidation()) {
        var requestData = {
            Id: parseInt($("#id").val()),
            Title: $("#title").val(),
            StartDate: $("#appointmentDate").val(),
            Duration: $("#duration").val(),
            TeacherId: $("#teacherId").val(),
            StudentId: $("#studentId").val(),
            StyleId: $("#styleId").val(),
            ClassTypeId: $("#classTypeId").val(),       
        };

        $.ajax({
            url: routeURL + '/api/Appointment/SaveCalendarData',
            type: 'POST',
            data: JSON.stringify(requestData),
            contentType: 'application/json',
            success: function (response) {
                if (response.status === 1 || response.status === 2) {
                    calendar.refetchEvents();
                    $.notify(response.message, "success");
                    onCloseModal();
                }
                else {
                    $.notify(response.message, "error");
                }
            },
            error: function (xhr) {
                $.notify("Error", "error");
            }
        });
    }
}

function checkValidation() {
    var isValid = true;
    if ($("#title").val() === undefined || $("#title").val() === "") {
        isValid = false;
        $("#title").addClass('error');
    }
    else {
        $("#title").removeClass('error');
    }

    if ($("#appointmentDate").val() === undefined || $("#appointmentDate").val() === "") {
        isValid = false;
        $("#appointmentDate").addClass('error');
    }
    else {
        $("#appointmentDate").removeClass('error');
    }
    return isValid;

}

function getEventDetailsByEventId(info) {
    $.ajax({
        url: routeURL + '/api/Appointment/GetCalendarDataById/' + info.id,
        type: 'GET',
        dataType: 'JSON',
        success: function (response) {

            if (response.status === 1 && response.dataenum !== undefined) {
                onShowModal(response.dataenum, true);
            }
            successCallback(events);
        },
        error: function (xhr) {
            $.notify("Error", "error");
        }
    });
}

function onTeacherChange() {
    calendar.refetchEvents();
}

function onDeleteAppointment() {
    var id = parseInt($("#id").val());
    $.ajax({
        url: routeURL + '/api/Appointment/DeleteAppoinment/' + id,
        type: 'GET',
        dataType: 'JSON',
        success: function (response) {

            if (response.status === 1) {
                $.notify(response.message, "success");
                calendar.refetchEvents();
                onCloseModal();
            }
            else {

                $.notify(response.message, "error");
            }
        },
        error: function (xhr) {
            $.notify("Error", "error");
        }
    });
}

function onConfirm() {
    var id = parseInt($("#id").val());
    $.ajax({
        url: routeURL + '/api/Appointment/ConfirmEvent/' + id,
        type: 'GET',
        dataType: 'JSON',
        success: function (response) {

            if (response.status === 1) {
                $.notify(response.message, "success");
                calendar.refetchEvents();
                onCloseModal();
            }
            else {

                $.notify(response.message, "error");
            }
        },
        error: function (xhr) {
            $.notify("Error", "error");
        }
    });
}