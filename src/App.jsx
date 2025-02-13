import React, { useState } from "react";
import { BrowserRouter as Router, Routes, Route, NavLink } from "react-router-dom";
import { Home } from "./Home";
import './Lakasfoglalas.css';

export const App = () => {
  const [showLogin, setShowLogin] = useState(false);

  const openForm = () => setShowLogin(true);
  const closeForm = () => setShowLogin(false);
    return (
      <Router>
      <nav className="navbar navbar-expand-sm navbar-dark bg-dark">
        <div className="container-fluid">
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
                <NavLink to="/upload" className={({ isActive }) => "nav-link" + (isActive ? " active" : "")}>Feltöltés</NavLink>
              </li>
              <li className="nav-item">
                <NavLink to="/" className={({ isActive }) => "nav-link" + (isActive ? " active" : "")}>Regisztráció</NavLink>
              </li>
            </ul>
            <button className="btn btn-outline-light" onClick={openForm}>Login</button>
          </div>
        </div>
        {showLogin && (
        <div className="form-popup position-fixed top-50 start-50 translate-middle bg-white p-4 border shadow" id="myForm">
          <form className="form-container">
            <h1>Login</h1>
            <label htmlFor="email"><b>Email</b></label>
            <input type="text" placeholder="Enter Email" name="email" required className="form-control mb-2" />
            <label htmlFor="psw"><b>Password</b></label>
            <input type="password" placeholder="Enter Password" name="psw" required className="form-control mb-2" />
            <button type="submit" className="btn btn-success w-100 mb-2">Login</button>
            <button type="button" className="btn btn-danger w-100" onClick={closeForm}>Close</button>
          </form>
        </div>
      )}
      </nav>

      <nav className="side-nav bg-dark text-white p-0">
        <NavLink to="#" className="side-link d-block text-white fs-6">Budapest</NavLink>
        <NavLink to="#" className="side-link d-block text-white fs-6">Debrecen</NavLink>
        <NavLink to="#" className="side-link d-block text-white fs-6">Miskolc</NavLink>
        <NavLink to="#" className="side-link d-block text-white fs-6">Szeged</NavLink>
        <NavLink to="#" className="side-link d-block text-white fs-6">Pécs</NavLink>
        <NavLink to="#" className="side-link d-block text-white fs-6">Győr</NavLink>
        <NavLink to="#" className="side-link d-block text-white fs-6">Kecskemét</NavLink>
        <NavLink to="#" className="side-link d-block text-white fs-6">Nyíregyháza</NavLink>
      </nav>
      <div className="container-fluid d-flex">
        <div className="content flex-grow-1 p-3">
          <Routes>
            <Route path="/" element={<Home />} />
          </Routes>
          
        </div>
      </div>
      </Router>
    );
  }

