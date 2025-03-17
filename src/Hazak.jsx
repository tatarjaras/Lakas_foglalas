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
            <i className="bi bi-heart-pulse"></i> Lakasok
          </h2>
          <div className="row">
            {LakasList.map((lakas) => (
              <div key={lakas.id} className="col-md-6">
                <div className="card shadow-sm mb-3">
                  <div className="card-body text-center">
                    <i className="bi bi-person-badge fs-1 text-secondary"></i>
                    <h5 className="card-title mt-2">{lakas.utca}</h5>
                    <p className="card-text text-muted">{lakas.meret}</p>
                    <p className="card-text text-muted">{lakas.szobakSzama}</p>
                    <p className="card-text text-muted">{lakas.ar}</p>
                    <p className="card-text text-muted">{lakas.leiras}</p>
                    <p className="card-text text-muted">{lakas.varosId}</p>
                  </div>
                </div>
              </div>
            ))}
          </div>
        </div>
    );
};