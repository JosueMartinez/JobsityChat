"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

var counter = 0;   //number of messages received
var limit = 50;    //numer of messages to show in chat

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message, time) {
    counter++;

    $('<li class="message-container" id="' + counter + '">'
        + '<p class="font-weight-bold">' + user + ':</p>'
        + '<p>' + message + '</p>'
        + '<span class="time-right">' + time + '</span>'
        + '</li>').appendTo('#messagesList');

    if (counter > limit) {
        removeElement(counter - limit);
    }

});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;

}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("username").value;
    var message = document.getElementById("message-to-send").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    document.getElementById("message-to-send").value = "";
    event.preventDefault();
});

function removeElement(id) {
    var element = document.getElementById(id);
    return element.parentNode.removeChild(element);
}