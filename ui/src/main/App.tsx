import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import Header from './Header';
import HouseDetail from '../house/HouseDetail';
import HouseList from '../house/HouseList';


function App() {
  return (
    <BrowserRouter>
      <div className="container">
        <Header subtitle="EXPENSIVE HOUSING" />
        <Routes>
          <Route path="/" element={<HouseList />}></Route>
          <Route path="/house/:id" element={<HouseDetail />}></Route>
        </Routes>

      </div>
    </BrowserRouter>
  );
}

export default App;
