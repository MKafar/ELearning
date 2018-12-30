import React, { Component } from 'react'
import CodeMirror from 'react-codemirror'
import { Button } from 'semantic-ui-react'

import './CodeMirror.scss'
import 'codemirror/lib/codemirror.css'
import 'codemirror/mode/clike/clike'
import 'codemirror/theme/neat.css'
import 'codemirror/addon/edit/closebrackets.js'




class Codemirror extends Component {
    state = {
        name: 'CodeMirror',
        code: '// Code Here'
    };

    runCodeHandler = () => {
        console.log(this.state.code)
    }

    updateCode(newCode) {
        this.setState({
            code: newCode,
        });
    }

    render() {

        let options = {
            lineNumbers: true,
            mode: 'text/x-c++src',
            theme: 'neat',
            autoCloseBrackets: true,
        };

        return (
            <div>
                <CodeMirror value={this.state.code} onChange={this.updateCode.bind(this)} options={options} />
                <Button onClick={this.runCodeHandler}>Run</Button>
            </div>
        );
    }
}

export default Codemirror;
