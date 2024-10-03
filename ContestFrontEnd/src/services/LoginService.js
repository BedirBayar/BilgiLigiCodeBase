
//// loginService.js
//import { useAuth } from '../components/AuthProvider';

//const LoginService = async (credentials) => {
//    const { login } = useAuth();

//    try {
        
//        await login(checkEmail(credentials));
//    } catch (error) {
//        console.error('Login failed', error);
//    }

//    function checkEmail(credentials) {
//        var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
//        if (regex.test(credentials.owner))
//            return {
//                email: credentials.owner,
//                username:"",
//                password: credentials.password
//            }
//            else return {
//                email:"",
//                userName: credentials.owner,
//                password: credentials.password
//            }
//    }
//};

//export default LoginService;