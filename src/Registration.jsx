import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import sha256 from "js-sha256";

export const Registration = () => {
  const [formData, setFormData] = useState({
    loginNev: "",
    jelszo: "",
    Name: "",
    email: "",
  });

  const navigate = useNavigate();

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const generateSalt = (length) => {
    const characters =
      "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    let salt = "";
    for (let i = 0; i < length; i++) {
      const randomIndex = Math.floor(Math.random() * characters.length);
      salt += characters.charAt(randomIndex);
    }
    return salt;
  };

  const handleSubmit = async () => {
    // Validáció
    if (!formData.loginNev || !formData.jelszo || !formData.Name || !formData.email) {
      alert("Minden mezőt ki kell tölteni!");
      return;
    }

    const salt = generateSalt(64);
    const hashedPassword = sha256(formData.jelszo + salt);

    const requestBody = {
      id: 0,
      loginNev: formData.loginNev,
      name: formData.Name,
      salt,
      hash: hashedPassword,
      email: formData.email,
      permissionId: 1,
      active: 0,
      profilePicturePath: "avatar.jpg",
    };

    console.log("Küldött adatok:", requestBody);

    try {
      const response = await axios.post(
        "http://localhost:5000/api/Registry", // Ha HTTPS szükséges, akkor az URL-en módosítani kell
        requestBody,
        { headers: { "Content-Type": "application/json" } }
      );

      alert("Sikeres regisztráció!");
      navigate("/");
    } catch (error) {
      if (error.response) {
        console.error("Regisztrációs hiba:", error.response.data);
        alert(`Hiba történt: ${error.response.data?.message || "Ismeretlen hiba"}`);
      } else if (error.request) {
        console.error("Hálózati hiba:", error.message);
        alert("Nem sikerült csatlakozni a szerverhez. Ellenőrizd, hogy a backend fut-e!");
      } else {
        console.error("Hiba:", error.message);
        alert("Ismeretlen hiba történt.");
      }
    }
  };

  return (
    <div
      style={{
        position: "absolute",
        top: "50%",
        left: "50%",
        transform: "translate(-50%, -50%)",
        backgroundColor: "rgba(0, 0, 0, 0.5)",
        padding: "20px",
        borderRadius: "10px",
        textAlign: "center",
        color: "#fff",
      }}
    >
      <h2>Regisztráció</h2>
      <input
        type="text"
        name="Name"
        placeholder="Teljes név"
        value={formData.Name}
        onChange={handleChange}
        style={{ margin: "10px", padding: "10px", borderRadius: "5px", width: "80%" }}
      />
      <input
        type="text"
        name="loginNev"
        placeholder="Felhasználónév"
        value={formData.loginNev}
        onChange={handleChange}
        style={{ margin: "10px", padding: "10px", borderRadius: "5px", width: "80%" }}
      />
      <input
        type="email"
        name="email"
        placeholder="E-mail"
        value={formData.email}
        onChange={handleChange}
        style={{ margin: "10px", padding: "10px", borderRadius: "5px", width: "80%" }}
      />
      <input
        type="password"
        name="jelszo"
        placeholder="Jelszó"
        value={formData.jelszo}
        onChange={handleChange}
        style={{ margin: "10px", padding: "10px", borderRadius: "5px", width: "80%" }}
      />
      <br />
      <button
        onClick={handleSubmit}
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
      >
        Regisztráció
      </button>
    </div>
  );
};
