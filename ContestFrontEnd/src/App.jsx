import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

function App() {
  const [count, setCount] = useState(0)

  return (
      <AuthProvider>
          {/* Router t�m uygulamay� sar�yor */}
          <Router>
              {/* Genel layout, t�m sayfalar� ve bile�enleri sar�yor */}
              <Layout>
                  <Switch>
                      {/* Genel sayfalar */}
                      <Route path="/login" component={LoginPage} />

                      {/* Giri� yapmay� gerektiren �zel rotalar */}
                      <PrivateRoute path="/home" component={HomePage} />
                      <PrivateRoute path="/profile" component={ProfilePage} />

                      {/* Varsay�lan rota */}
                      <Route path="/" component={LoginPage} />
                  </Switch>
              </Layout>
          </Router>
      </AuthProvider> 
  )
}

export default App
