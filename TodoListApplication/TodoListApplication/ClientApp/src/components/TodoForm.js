import React, { useState, useEffect, useRef } from 'react';

function TodoForm(props) {
    const [input, setInput] = useState(props.edit ? props.edit.value : '');

    const inputRef = useRef(null);

    useEffect(() => {
        inputRef.current.focus();
    });

    const handleChange = e => {
        setInput(e.target.value);
    };

    const handleSubmit = e => {
        e.preventDefault();

        props.onSubmit({
            id: Math.floor(Math.random() * 10000), // creates unique! ids
            description: input,
            isCompleted : false,
        });
        setInput('');
    };

    return (
        <form onSubmit={handleSubmit}>
            {/*If it's on edit mode, when we are in updating mode */}
            {props.edit ? (
                <>
                    <input
                        placeholder={props.edit.description}
                        value={input}
                        onChange={handleChange}
                        name='text'
                        ref={inputRef}
                    />
                    <button onClick={handleSubmit}>Update</button>
                </>
            ) : (
                <>
                    <input
                        placeholder='Add a todo'
                        value={input}
                        onChange={handleChange}
                        name='text'
                        ref={inputRef}
                    />
                    <button onClick={handleSubmit}>Add todo</button>
                </>
            )}
        </form>
    );
}

export default TodoForm;