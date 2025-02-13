import React from "react";
import { Link } from "react-router-dom";

export const Home = () => {
    return (
        <div className="container mt-3">
  <br />
    <div className="mt-3">
      <div className="d-flex flex-row">
        <div className="img-container">
          <img src="1.jpg" alt="1" className="img-thumbnail" style={{maxWidth: "400px", height: "200px"}} />
          <p className="text-center"><Link to="/">További adatok</Link></p>
        </div>
        <div className="img-container">
          <img src="2.jpg" alt="2" className="img-thumbnail" style={{maxWidth: "400px", height: "200px"}} />
          <p className="text-center"><Link to="/">További adatok</Link></p>
        </div>
        <div className="img-container">
          <img src="3.jpg" alt="3" className="img-thumbnail" style={{maxWidth: "400px", height: "200px"}} />
          <p className="text-center"><Link to="/">További adatok</Link></p>
        </div>
      </div>
    </div>
  </div>
    );
}