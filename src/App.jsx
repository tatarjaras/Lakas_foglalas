import React, { useState } from "react";
import { BrowserRouter as Router, Routes, Route, NavLink } from "react-router-dom";
import { Home } from "./Home";
import axios from "axios";
import { useEffect } from "react";
import { Login } from "./Login";
import { Link } from "react-router-dom";
import { Registratio } from "./Registratio";
import { Hazak } from "./Hazak";
import { Feltolt } from "./Feltolt";
import { Vasarlas } from "./Vasarlas";
import "./Lakasfoglalas.css";

// Háttérképek listája
const images = [
 "https://images.unsplash.com/photo-1564013799919-ab600027ffc6",
  "https://images.unsplash.com/photo-1600585154340-be6161a56a0c",
  "https://images.unsplash.com/photo-1572120360610-d971b9d7767c",
  "1.jpg",
  "2.jpg",
  "3.jpg",
];

//https://images.pexels.com/photos/3147997/pexels-photo-3147997.jpeg

// Változó háttér komponens
export const ChangingBackground = () => {
  const [currentImage, setCurrentImage] = useState(images[0]);

  useEffect(() => {
    const interval = setInterval(() => {
      setCurrentImage((prevImage) => {
        const currentIndex = images.indexOf(prevImage);
        const nextIndex = (currentIndex + 1) % images.length;
        return images[nextIndex];
      });
    }, 10000);

    return () => clearInterval(interval);
  }, []);

  return <div className="bg" style={{ backgroundImage: `url(${currentImage})` }} />;
};


const API_BASE_URL = 'http://localhost:5000/api/';
export const App = () => {
  const [showLogin, setShowLogin] = useState(false);
  const [varosok, setVarosok] = useState([]);
  useEffect(() => {
    axios.get(`${API_BASE_URL}Varosok/token`)
      .then(response => {
        console.log(response.data);
        setVarosok(response.data);
      })
      .catch(error => console.error('Hiba történt:', error));
  }, []);

  const openForm = () => setShowLogin(true);
  const closeForm = () => setShowLogin(false);
    return (
      <Router>
      <nav className="navbar navbar-expand-sm navbar-dark bg-dark">
        <div className="container-fluid">
          <ChangingBackground />
          <div className="navbar-brand">Lakásfoglalás</div>
          <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarNav">
            <ul className="navbar-nav">
              <li className="nav-item">
                <NavLink to="/" className={({ isActive }) => "nav-link" + (isActive ? " active" : "")}>Főoldal</NavLink>
              </li>
              <li className="nav-item">
                <NavLink to="/feltolt" className={({ isActive }) => "nav-link" + (isActive ? " active" : "")}>Feltöltés</NavLink>
              </li>
              <li className="nav-item">
                <NavLink to="/Hazak" className={({ isActive }) => "nav-link" + (isActive ? " active" : "")}>Lakások</NavLink>
              </li>
              <li className="nav-item">
                <NavLink to="/Registratio" className={({ isActive }) => "nav-link" + (isActive ? " active" : "")}>Regisztráció</NavLink>
              </li>
              
            </ul>
            <button 
              className="btn btn-light ms-3"> <Link className="nav-link" to="/login">
              <i className="bi bi-person-circle" style={{ fontSize: '24px' }}>Login</i></Link>
            </button>
          </div>
        </div>
      </nav>

      
      <div className="container-fluid d-flex">
        <div className="content flex-grow-1 p-3">
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/Feltolt" element={<Feltolt />} />
            <Route path="/Login" element={<Login />} />
            <Route path="/Registratio" element={<Registratio />} />
            <Route path="/Hazak" element={<Hazak />} />
            <Route path="/Vasarlas" element={<Vasarlas />} />
          </Routes>
          
        </div>
      </div>
      </Router>
    );
  }

  //93*
//<nav className="side-nav bg-dark text-white p-0">
//{varosok.map((varos) => (
  //<div key={varos.id} className="side-link d-block text-white fs-6">
  //<NavLink to="#" className="side-link d-block text-white fs-6">{varos.varos}</NavLink>
//</div>
//))}
//</nav>