import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <div>
                <h1>Hello There and Welcome!</h1>
                <h3>Overview</h3>
                <p>This is a simple single-page web application that provides a todo list that user can</p>
                <ul>
                    <li> add new items</li>
                    <li>update an existing one</li>
                    <li>mark it as complete</li>
                    <li>delete an item</li>
                </ul>
                <p>On top right of the page you can go to todo list page. Use the text box to add the description and click add.
                The Item should appear under with a checkbox that shows if the item is completed (checked) or not - default is not.
                Beside the check box there are two other buttons, Delete; to delete the item and Update; which goes to editing mode.
                Please note that in editing note, it will show the empty string and user can select anything. Except empty string.
                </p>
                <h3>Technology</h3>
                <p>The solution contains both server side and client side of the service. I am using the template ASP.Net Core with React.js</p>
                <ul>
                    <li>Client side is written in javascript - using React.</li>
                    <li>Server side is written in C# - using .Net Framework</li>
                </ul>
                <p>For each modification on UI side, a request (post/patch/delete) will be sent to server and after that the whole
                list will be fetched again by get request. The implementation of TodoList is in memory. Although the controller
                is using the interface, meaning that any implementation of that interface (ex: using Database) can replace the existing one</p>
                <h3>How to start the solution</h3>
                <p>Open the project using Visual Studio that supports .Net5. Start the project - it might take sometime to get npm packages</p>
                <h3>Remarks</h3>
                <p>Unfortunately, the test cases are missing for UI side</p>
            </div>
        );
    }
}