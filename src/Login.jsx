import React, { useEffect, useState} from "react";
import axios from "axios";
import sha256 from "js-sha256";

export const Login = () => {
  const [loginName, setLoginName] = useState("");
  const [password, setPassword] = useState("");
  const [user, setUser] = useState(null);
  const [avatar, setAvatar] = useState("");


  useEffect(() => {
    const storedUser = localStorage.getItem("felhasz");
    if (storedUser) {
      const parsedUser = JSON.parse(storedUser);
      setUser(parsedUser);
      setAvatar(`http://images.balazska.nhely.hu/${parsedUser.profilePicturePath}`);
    }
  }, []);

  const handleLogin = async () => {
    try {
      const saltResponse = await axios.post(
        `http://localhost:5000/api/Login/SaltRequest/${loginName}`
      );
      const salt = saltResponse.data;
      const tmpHash = sha256(password + salt.toString());
      const loginResponse = await axios.post("http://localhost:5000/api/Login", {
        loginName,
        tmpHash,
      });

      if (loginResponse.status === 200) {
        let userData = loginResponse.data;
        localStorage.setItem("felhasz", JSON.stringify(userData));
        setUser(userData);
        setAvatar(`http://images.balazska.nhely.hu/${userData.profilePicturePath}`);
        alert(`Sikeres bejelentkezés! Felhasználó: ${userData.name}`);
      } else {
        alert("Hiba történt a bejelentkezéskor!");
      }
    } catch (error) {
      alert("Hiba történt: " + error.message);
    }
  };

  const handleLogout = async () => {
    if (user?.token) {
      try {
        const logoutUrl = `http://localhost:5000/api/Logout/${user.token}`;
        const response = await axios.post(logoutUrl);
        console.log(response.data);
      } catch (error) {
        console.error("Hiba történt a kijelentkezés során:", error);
      }
    }

    localStorage.removeItem("felhasz");
    setUser(null);
    setAvatar("");
    alert("Sikeres kijelentkezés!");
    window.location.reload(); // Oldal újratöltése, hogy a login form jelenjen meg
  };

  return (
    <div style={{ height: "90vh", color: "#fff", overflow: "hidden" }}>
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
        {user ? (
          <>
            <h2>Belépve: {user.name}</h2>
            {avatar && <img src={avatar} width="60%" height="60%" alt="Avatar" style={{ marginTop: "20px", borderRadius: "50%" }} />}
            <button
              onClick={handleLogout}
              style={{
                marginTop: "20px",
                padding: "10px 20px",
                borderRadius: "5px",
                backgroundColor: "#dc3545",
                color: "#fff",
                border: "none",
                cursor: "pointer",
              }}
            >
              Kijelentkezés
            </button>
          </>
        ) : (
          <>
            <h2>Bejelentkezés</h2>
            <input
              type="text"
              placeholder="Felhasználónév"
              value={loginName}
              onChange={(e) => setLoginName(e.target.value)}
              style={{ margin: "10px", padding: "10px", borderRadius: "5px", width: "80%" }}
            />
            <input
              type="password"
              placeholder="Jelszó"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              style={{ margin: "10px", padding: "10px", borderRadius: "5px", width: "80%" }}
            />
            <button
              onClick={handleLogin}
              style={{
                margin: "10px",
                padding: "10px 20px",
                borderRadius: "5px",
                backgroundColor: "#1e90ff",
                color: "#fff",
                border: "none",
                cursor: "pointer",
              }}
            >
              Bejelentkezés
            </button>
          </>
        )}
      </div>
    </div>
  );
};