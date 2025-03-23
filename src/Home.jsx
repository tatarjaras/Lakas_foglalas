import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import "./Lakasfoglalas.css";

// Főoldal komponens
export const Home = () => {
  return (
    <div className="container text-center mt-5">
      
      <div className="card shadow-lg p-4 border-success mt-4">
      <h1 className="fw-bold">Isten hozta az Indoors Kft. oldalán.</h1>
      <p className="mt-3 lead text-gray-800 dark:text-gray-200">
      Weboldalunkon egyszerűen és gyorsan vásárolhatsz vagy értékesíthetsz ingatlanokat, a legjobb ajánlatok és lehetőségek érdekében.
      </p>
      </div>

      
    </div>
  );
};