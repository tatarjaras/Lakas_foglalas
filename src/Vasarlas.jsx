import React, { useState, useEffect } from 'react';
import axios from 'axios';

const API_BASE_URL = 'http://localhost:5000/api/';
const id = 1;

export const Vasarlas = () => {
    const [LakasList, setLakasList] = useState([]);
    const [isModalOpen, setIsModalOpen] = useState(false); // Modal állapota

    useEffect(() => {
        axios.get(`${API_BASE_URL}Lakasok/${id}token`)
            .then(response => {
                console.log(response.data);
                setLakasList(response.data);
            })
            .catch(error => console.error('Hiba történt:', error));
    }, []);

    return (
        <div
            style={{
                position: "absolute",
                top: "500px",
                left: "50%",
                transform: "translate(-50%, -50%)",
                backgroundColor: "rgba(0, 0, 0, 0.5)",
                padding: "20px",
                borderRadius: "10px",
                textAlign: "center",
                color: "#fff",
            }}
        >
            <h2 className="lakas-title text-center mb-4">
                <i className="bi"></i>
            </h2>

            <div className="row">
                {LakasList.map((lakas) => (
                    <div key={lakas.id} className="col-md-6">
                        <div className="card shadow-sm mb-3">
                            <div className="card-body text-center">
                                <img src="missing.avif" alt="Lakás képe" className="img-fluid mb-3 float-start" style={{ maxHeight: "200px", objectFit: "cover" }} />
                                <h5 className="card-title mt-2 text-end">Utca: {lakas.utca}</h5>
                                <p className="card-text text-muted text-end">Méret: {lakas.meret}m²</p>
                                <p className="card-text text-muted text-end">Szobák száma: {lakas.szobakSzama}db</p>
                                <p className="card-text text-muted text-end">Ár: {lakas.ar}.FT</p>
                                <p className="card-text text-muted text-end">Leirás: {lakas.leiras}</p>
                                <p className="card-text text-muted text-end">Város: {lakas.varosId}</p>
                            </div>
                        </div>
                    </div>
                ))}
            </div>

            <h2>Vásárlás</h2>
            <input type="text" name="Name" placeholder="Kártyatulajdonos neve" style={{ margin: "10px", padding: "10px", borderRadius: "5px", width: "80%" }} />
            <input type="text" name="Bankszam" placeholder="Bankártyaszám" style={{ margin: "10px", padding: "10px", borderRadius: "5px", width: "80%" }} />
            <input type="text" name="date" placeholder="Kártya lejárati dátuma (MM/YY)" style={{ margin: "10px", padding: "10px", borderRadius: "5px", width: "80%" }} />
            <input type="password" name="CVC" placeholder="CVC/CVV" style={{ margin: "10px", padding: "10px", borderRadius: "5px", width: "80%" }} /><br />

            
            <button
                style={{
                    margin: "10px",
                    padding: "10px 20px",
                    borderRadius: "5px",
                    backgroundColor: "white",
                    color: "black",
                    border: "none",
                    cursor: "pointer",
                    fontWeight: "bold",
                }}
                onClick={() => setIsModalOpen(true)} 
            >
                Vásárlás véglegesítése
            </button>

           
            {isModalOpen && (
                <div
                    style={{
                        position: "fixed",
                        top: "0",
                        left: "0",
                        width: "100%",
                        height: "100%",
                        backgroundColor: "rgba(0, 0, 0, 0.5)",
                        display: "flex",
                        justifyContent: "center",
                        alignItems: "center",
                    }}
                >
                    <div
                        style={{
                            backgroundColor: "white",
                            padding: "20px",
                            borderRadius: "10px",
                            textAlign: "center",
                            color: "black",
                        }}
                    >
                        <h2>Vásárlás sikeres</h2>
                        <p>Köszönjük, hogy nálunk vásárolt!</p>
                        <button
                            style={{
                                marginTop: "10px",
                                padding: "5px 15px",
                                borderRadius: "5px",
                                backgroundColor: "red",
                                color: "white",
                                border: "none",
                                cursor: "pointer",
                            }}
                            onClick={() => setIsModalOpen(false)} // Modal bezárása
                        >
                            Bezárás
                        </button>
                    </div>
                </div>
            )}
        </div>
    );
};
