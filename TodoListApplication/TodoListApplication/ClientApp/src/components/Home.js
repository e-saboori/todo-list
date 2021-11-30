import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <div>
                <h1>Hello there and welcome!</h1>
                <p>This is a single-page web application that provides a todo list app</p>
                <p>The server side is a REST API written in C# on top of .Net framework</p>
                <p>The UI side of application is written using React</p>
            </div>
        );
    }
}