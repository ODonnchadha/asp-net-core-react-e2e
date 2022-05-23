import React from 'react';
import './App.css';
import Header from './Header';
import HouseList from '../house/HouseList';

function App() {
  return (
    <div className="container">
      <Header subtitle="PROVIDING EXPENSIVE HOUSING ALL OVER THE ENTIRE WORLD" />
      <HouseList />
    </div>
  );
}

export default App;
