import React, { useState } from 'react';
import TodoForm from './TodoForm';

const Todo = ({ todos, completeTodo, removeTodo, updateTodo }) => {
    const [edit, setEdit] = useState({
        id: null,
        description: ''
    });

    const submitUpdate = description => {
        updateTodo(edit.id, description);
        setEdit({
            id: null,
            description: ''
        });
    };

    if (edit.id) {
        return <TodoForm edit={edit} onSubmit={submitUpdate} />;
    }

    return todos.map((todo, index) => (
        <div key={index}>
            <label key={todo.id}> {todo.description}</label>
            <input type="checkbox" checked={todo.isCompleted} onChange={() => completeTodo(todo.id)} />
            <button onClick={() => removeTodo(todo.id)} >Delete</button>
            <button onClick={() => setEdit({ id: todo.id, description: todo.description })} >Update</button>
        </div>
    ));
};

export default Todo;