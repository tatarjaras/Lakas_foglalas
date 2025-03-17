import React, { useState, useEffect } from 'react';
import axios from 'axios';

const API_BASE_URL = 'http://localhost:5000/api/';

export const Hazak = () => {
    const [LakasList, setLakasList] = useState([]);

    useEffect(() => {
        axios.get(`${API_BASE_URL}Lakasok/token`)
            .then(response => {
                console.log(response.data);
                setLakasList(response.data);
            })
            .catch(error => console.error('Hiba történt:', error));
    }, []);
    return (
        <div className="container mt-4">
          <h2 className="text-primary text-center mb-4">
            <i className="bi bi-house-door"></i> Lakasok
          </h2>
          <div className="row">
            {LakasList.map((lakas) => (
              <div key={lakas.id} className="col-md-6">
                <div className="card shadow-sm mb-3 ">
                  <div className="card-body text-center">
                  <img src="missing.avif" alt="Lakás képe" className="img-fluid mb-3 float-start" style={{ maxHeight: "200px", objectFit: "cover" }} />
                    <h5 className="card-title mt-2  text-end">Utca: {lakas.utca}</h5>
                    <p className="card-text text-muted  text-end">Méret: {lakas.meret}m²</p>
                    <p className="card-text text-muted  text-end">Szobák száma: {lakas.szobakSzama}db</p>
                    <p className="card-text text-muted  text-end">Ár: {lakas.ar}.FT</p>
                    <p className="card-text text-muted  text-end">Leirás: {lakas.leiras}</p>
                    <p className="card-text text-muted  text-end">Város: {lakas.varosId}</p>
                  </div>
                </div>
              </div>
            ))}
          </div>
        </div>
    );
};