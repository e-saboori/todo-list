# todo-list
## Overview
This is a simple single-page web application that provides a todo list that user can
-add new items
-update an existing one
-mark it as complete
-delete an item
On top right of the page you can go to todo list page. Use the text box to add the description and click add.
The Item should appear under with a checkbox that shows if the item is completed (checked) or not - default is not.
Beside the check box there are two other buttons, Delete; to delete the item and Update; which goes to editing mode.
Please note that in editing note, it will show the empty string and user can select anything. Except empty string.

## Technology
The solution contains both server side and client side of the service. I am using the template ASP.Net Core with React.js
-Client side is written in javascript - using React.
-Server side is written in C# - using .Net Framework
For each modification on UI side, a request (post/patch/delete) will be sent to server and after that the whole
list will be fetched again by get request. The implementation of TodoList is in memory. Although the controller
is using the interface, meaning that any implementation of that interface (ex: using Database) can replace the existing one

## How to start the solution
Open the project using Visual Studio that supports .Net5. Start the project - it might take sometime to get npm packages
