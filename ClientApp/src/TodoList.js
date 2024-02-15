import React, { useState, useEffect } from 'react';
import axios from 'axios';

function TodoList() {
  const [todos, setTodos] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:15815/api/task')
      .then(response => {
        setTodos(response.data);
      })
      .catch(error => {
        console.error('Error fetching data: ', error);
      })
  }, []);

  return (
    <ul>
      {todos.map(todo => (
        <li key={todo.id}>{todo.title}</li>
      ))}
    </ul>
  );
}

export default TodoList;