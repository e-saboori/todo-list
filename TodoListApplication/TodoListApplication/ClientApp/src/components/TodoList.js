import React, { useState, useEffect } from 'react';
import TodoForm from './TodoForm';
import Todo from './Todo';

function TodoList() {
    const [todos, setTodos] = useState([]);

    useEffect(() => {
        //This is to update the list when user goes back to todo list page
        populateTodoListItems()
        return () => {};
    }, []);

    const addTodo = async todo => {
        // Only add the item if the description is not empty
        if (!todo.description) {
            return;
        }

        // Post the item
        await fetch('todolist/items', {
            method: 'POST',
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(todo)
        }).then(async () => { await populateTodoListItems(); })
    };

    const updateTodo = async (todoId, newValue) => {
        if (!newValue.description || /^\s*$/.test(newValue.description)) {
            return;
        }

        // Find the todo item that it's id matches the updated todo item
        todos.map(async todo => {
            if (todo.id === todoId) {
                todo.description = newValue.description;
            }

            // Send the item to server side
            await fetch('todolist/items/' + todo.id, {
                method: 'PATCH',
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(todo)
            }).then(async () => { await populateTodoListItems(); })
        });
    };

    const removeTodo = async id => {
        //Send the delete request to server
        await fetch('todolist/items/' + id, {
            method: 'DELETE',
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ id: id })
        }).then(async () => { await populateTodoListItems(); })
    };

    const completeTodo = async id => {
        //Find the todo item that it's id matched the updated id
        todos.map(async todo => {
            if (todo.id === id) {
                todo.isCompleted = !todo.isCompleted;
            }

            //Send the update to the server
            await fetch('todolist/items/' + todo.id, {
                method: 'PATCH',
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(todo)
            }).then(async () => { await populateTodoListItems(); })
            return;
        });
    };

    //This is the function to get the items from server
    //This functio is being called after every update/delete that being sent to server
    //To show updated list
    const populateTodoListItems = async () => {
        const response = await fetch('todolist');
        const data = await response.json();
        setTodos(data);
    }

    return (
        <>
            <h1>Here you can add, update or delete your todo items...</h1>
            <TodoForm onSubmit={addTodo} />
            <div width="400px">
                <Todo
                    todos={todos}
                    completeTodo={completeTodo}
                    removeTodo={removeTodo}
                    updateTodo={updateTodo}
                />
            </div>
        </>
    );
}

export default TodoList;