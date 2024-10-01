import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

function App() {
  const [count, setCount] = useState(0)

  return (
      <AuthProvider>
          {/* Router tüm uygulamayý sarýyor */}
          <Router>
              {/* Genel layout, tüm sayfalarý ve bileþenleri sarýyor */}
              <Layout>
                  <Switch>
                      {/* Genel sayfalar */}
                      <Route path="/login" component={LoginPage} />

                      {/* Giriþ yapmayý gerektiren özel rotalar */}
                      <PrivateRoute path="/home" component={HomePage} />
                      <PrivateRoute path="/profile" component={ProfilePage} />

                      {/* Varsayýlan rota */}
                      <Route path="/" component={LoginPage} />
                  </Switch>
              </Layout>
          </Router>
      </AuthProvider> 
  )
}

export default App
