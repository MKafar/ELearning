import React, { Component } from 'react';
import 'semantic-ui-css/semantic.min.css'
import 'semantic-ui-react';

import './App.css';
import Grade from './Grades/Grade';
//import LoginInput from './Login/Login.jsx';
//import Codemirror from './CodeMirror/CodeMirror.jsx';
//import Output from './CodeMirror/Output.jsx';
//import Runbutton from './CodeMirror/RunButton';
import Menu from './Menu/Menu.jsx';
//import LoginButton from './Login/LoginButton.jsx';
//import Grade from './Grades/Grade.jsx';


class App extends Component {
  render() {
    return (
      <div className='App'>
        <div className =" block">
          <div className="menu">
            <Menu></Menu>
          </div>
          <div>
            <Grade></Grade>
          </div>

        </div>
        











        {/*
      <div className = "menu">
      <Menu></Menu>
      </div>
        <div className="logincontainer">
          <LoginInput></LoginInput>
          <LoginButton></LoginButton>
        </div>
        

         <div className='coding'>
          <Codemirror></Codemirror>
          <Output></Output>
        </div>
        */}

      </div>
    );
  }
}

export default App;