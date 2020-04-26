# JobsityChat

## Setup

Run migrations `Update-Database -v`   (using localdb for this project)

### Project 

Need to register into the application to join the chatroom.
After register you can go into the chatroom and start messaging.

Using SignalR Library for real-time messages showing.  All messages, but the stock command and but response, are saved in db.
When joinning chatroom, the last 50 messages in db are shown.
