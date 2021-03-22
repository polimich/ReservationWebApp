import { createContext, useReducer, useContext } from "react";

//* Definice Kontexu aplikace, nastavení globálně přístupných proměnných, vytvoření provideru
const initialState = {
  accessToken: null,
  name: null,
  role: null,
  userId: null,
  whatITeach: null,
};
export const SET_ACCESS_TOKEN = "SET_ACCESS_TOKEN";
export const SET_NAME = "SET_NAME";
export const SET_ROLE = "SET_ROLE";
export const SET_USER_ID = "SET_USER_ID";
export const SET_WHAT_I_TEACH = "SET_WHAT_I_TEACH";
const appReducer = (state, action) => {
  switch (action.type) {
    case SET_ACCESS_TOKEN: {
      return { ...state, accessToken: action.payload };
    }
    case SET_NAME: {
      return { ...state, name: action.payload };
    }
    case SET_ROLE: {
      return { ...state, role: action.payload };
    }
    case SET_USER_ID: {
      return { ...state, userId: action.payload };
    }
    case SET_WHAT_I_TEACH: {
      return { ...state, whatITeach: action.payload };
    }
    default: {
      return state;
    }
  }
};
export const AppContext = createContext();
export const AppProvider = ({ children, ...rest }) => {
  const [store, dispatch] = useReducer(appReducer, initialState);
  return (
    <AppContext.Provider value={[store, dispatch]}>
      {children}
    </AppContext.Provider>
  );
};
export const useAppContext = () => useContext(AppContext);
