import React, { useState, useEffect } from 'react';
import axios from 'axios';

const API_BASE_URL = 'http://localhost:5000/api/';
const id = 1;

export const Feltolt = () => {
    const [LakasList, setLakasList] = useState([]);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [formData, setFormData] = useState({
        Id: '',
        Utca: '',
        Meret: '',
        SzobakSzama: '',
        Ar: '',
        Leiras: '',
        Varos: ''
    });

    useEffect(() => {
        axios.get(`${API_BASE_URL}Lakasok/${id}token`)
            .then(response => {
                console.log(response.data);
                setLakasList(response.data);
            })
            .catch(error => console.error('Hiba történt:', error));
    }, []);

    const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const fieldLabels = {
        Id: 'Azonosító',
        Utca: 'Utca',
        Meret: 'Méret (m²)',
        SzobakSzama: 'Szobák száma',
        Ar: 'Ár (Ft)',
        Leiras: 'Leírás',
        Varos: 'Város'
    };

    return (
        <div style={{
            position: "absolute",
            top: "500px",
            left: "50%",
            transform: "translate(-50%, -50%)",
            backgroundColor: "rgba(0, 0, 0, 0.5)",
            padding: "20px",
            borderRadius: "10px",
            textAlign: "center",
            color: "#fff",
        }}>
            <h2>Lakás feltöltése</h2>
            {Object.keys(formData).map((key) => (
                <input
                    key={key}
                    type="text"
                    name={key}
                    placeholder={fieldLabels[key]}
                    value={formData[key]}
                    onChange={handleChange}
                    style={{ margin: "10px", padding: "10px", borderRadius: "5px", width: "80%" }}
                />
            ))}

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
                Lakás feltöltése
            </button>

            {isModalOpen && (
                <div style={{
                    position: "fixed",
                    top: "0",
                    left: "0",
                    width: "100%",
                    height: "100%",
                    backgroundColor: "rgba(0, 0, 0, 0.5)",
                    display: "flex",
                    justifyContent: "center",
                    alignItems: "center",
                }}>
                    <div style={{
                        backgroundColor: "white",
                        padding: "20px",
                        borderRadius: "10px",
                        textAlign: "center",
                        color: "black",
                    }}>
                        <h2>Lakás feltöltése sikeres</h2>
                        <p>A lakás adatai sikeresen feltöltve!</p>
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
                            onClick={() => setIsModalOpen(false)}
                        >
                            Bezárás
                        </button>
                    </div>
                </div>
            )}
        </div>
    );
};
