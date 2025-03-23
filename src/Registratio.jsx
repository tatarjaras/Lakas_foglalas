import React, { useState} from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import sha256 from "js-sha256";

export const Registratio = () => {
    const [formData, setFormData] = useState({
        loginNev: "",
        jelszo: "",
        Name: "",
        email: "",
        ProfilePicturePath: "avatar.jpg"
    });
    const navigate = useNavigate();

   
      const handleChange = (e) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
      };

      const generateSalt = (length) => {
        const characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        let SALT = "";
        for (let i = 0; i < length; i++) {
          const randomIndex = Math.floor(Math.random() * characters.length);
          SALT += characters.charAt(randomIndex);
        }
        return SALT;
      };
      const handleSubmit = async () => {
        const SALT = generateSalt(64);
        const hashedPassword = sha256(formData.jelszo + SALT);
    
        const requestBody = {
          Id: 0,
          loginNev: formData.loginNev,
          Name: formData.Name,
          SALT,
          HASH: hashedPassword,
          Email: formData.email,
          PermissionId: 1,
          Active: 0,
          ProfilePicturePath: "avatar.jpg",
        };
    
        console.log(requestBody);
    
        try {
          const response = await axios.post("https://localhost:5000/api/Registry", requestBody);
          alert(response.data);
          navigate("/");
        } catch (error) {
          console.error(error);
          alert("hiba történt a regisztráció során!");
        }
    };
      return(
        <div>
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
              type="text"
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
            /><br />
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
    </div>
      );
}