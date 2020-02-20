import React from 'react';
import { MatrixGrid } from './components/app/MatrixGrid'
import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h2>Square Matrix Rotation App</h2>
        <MatrixGrid />
      </header>
    </div>
  );
}

export default App;
