import React, { Component } from 'react'
import 'semantic-ui-css/semantic.min.css'
import 'semantic-ui-react'

import './App.css'
import Menu from './Menu/Menu.jsx'
import CodeMirror from './CodeMirror/CodeMirror.jsx'

class App extends Component {
  render() {
    return (
      <div className='App'>
        <div className =" block">
          <div className="menu">
            <Menu></Menu>
          </div>
          <div>
            <CodeMirror />
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