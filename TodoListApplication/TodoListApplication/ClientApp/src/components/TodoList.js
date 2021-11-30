import React, { useState, useEffect } from 'react';
import TodoForm from './TodoForm';
import Todo from './Todo';

function TodoList() {
    const [todos, setTodos] = useState([]);

    useEffect(() => {
        populateTodoListItems()
        return () => {
            // apparantly it does clean up
        };
    }, []);

    const addTodo = todo => {
        if (!todo.description) {
            return;
        }

        fetch('todolist/items', {
            method: 'POST',
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(todo)
        }).then(() => { populateTodoListItems(); })
    };

    const updateTodo = (todoId, newValue) => {
        if (!newValue.description || /^\s*$/.test(newValue.description)) {
            return;
        }
        todos.map(todo => {
            if (todo.id === todoId) {
                todo.description = newValue.description;
            }

            fetch('todolist/items/' + todo.id, {
            method: 'PATCH',
            headers: { "Content-Type": "application/json" },
                body: JSON.stringify(todo)
            }).then(() => { populateTodoListItems(); })
        });
    };

    const removeTodo = id => {
        fetch('todolist/items/' + id, {
            method: 'DELETE',
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ id: id })
        }).then(() => { populateTodoListItems(); })
    };

    const completeTodo = id => {
        todos.map(todo => {
            if (todo.id === id) {
                todo.isCompleted = !todo.isCompleted;
            }
            fetch('todolist/items/' + todo.id, {
                method: 'PATCH',
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(todo)
            }).then(() => { populateTodoListItems(); })
            return;
        });
    };

    const populateTodoListItems = async () => {
        const response = await fetch('todolist');
        const data = await response.json();
        setTodos(data);
        console.log(...todos);
    }
    return (
        <>
            <h1>Here you can add, update or delete your todo items...</h1>
            <TodoForm onSubmit={addTodo} />
            <div width= "400px">
            <Todo
                todos={todos}
                completeTodo={completeTodo}
                removeTodo={removeTodo}
                updateTodo={updateTodo}
            /></div>
        </>
    );
}

export default TodoList;