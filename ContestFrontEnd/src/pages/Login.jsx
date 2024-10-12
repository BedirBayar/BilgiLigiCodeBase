import "../assets/css/login.css"
import React, { useState, useContext } from 'react';
import { AuthContext } from '../components/AuthProvider'; // Import the context 
import { useNavigate } from 'react-router-dom';

function Login() {
    const { login } = useContext(AuthContext); // Get the login function from AuthProvider
    const [credentials, setCredentials] = useState({ owner: '', password: '' });
    const [error, setError] = useState('');
    const [loading, setLoading] = useState(false);
    const navigate = useNavigate();

    const handleLogin = async (e) => {
        e.preventDefault();
        const success = await login(credentials); // login işleminin sonucunu kontrol et
        debugger;
        if (success) {
            navigate('/dashboard'); // Başarılıysa yönlendir
        } else {
            console.error('Login failed'); // Hata varsa logla
        }
    };
   

    return <div className="container login-container">
        <form className="login-form" onSubmit={handleLogin}>
            <div className="form-group">
                <input className="form-control" type="text" name="owner" id="owner"
                    value={credentials.owner} onChange={(e) => setCredentials({ ...credentials, owner: e.target.value })}
                    placeholder="kullanıcı adı veya e-posta" required >
                </input>
            
            </div>
            <div className="form-group">
                <input className="form-control" type="password" name="password" id="password" placeholder="parola" value={credentials.password}
                    onChange={(e) => setCredentials({ ...credentials, password: e.target.value })}
                    required>
                </input>
            
            </div>
            <div className="form-group">
                {error && <p style={{ color: 'red' }}>{error}</p>}
                <button className="btn btn-success" type="submit" id="submit" disabled={loading}>
                    {loading ? 'Giriş Yapılıyor...' : 'Giriş'}
                </button>
               
            
            </div> 
        </form>
    </div>
}
export default Login