import React, { Component } from 'react';
import CodeMirror from 'react-codemirror';
import { Button } from 'semantic-ui-react';
import axios from '../../axios';

import './CodeMirror.scss';
import 'codemirror/lib/codemirror.css';
import 'codemirror/mode/clike/clike';
import 'codemirror/theme/neat.css';
import 'codemirror/addon/edit/closebrackets.js';

class Codemirror extends Component {
    state = {
        name: 'CodeMirror',
        code: '// Code Here',
        output: null,
    };

    runCodeHandler = () => {
        this.setState({ output: "waiting..." })
        console.log(this.state.code)
        axios.post('/api/Compiler/Run', {
            assignmentid: this.props.assignmentID,
            code: this.state.code
        }).then(response => {
            console.log(response.data);
            let outputString = response.data.output;
            let changedOutput = outputString.replace(/\r\n/g, "<br />");
            this.setState({ output: changedOutput });

        }).catch(error => {
            console.log(error.response);
        })
    }

    createMarkup = () => {
        return { __html: this.state.output };
    }

    updateCode(newCode) {
        this.setState({
            code: newCode,
        });
    }

    sendCodeHandler = () => {
        axios.post('/api/Compiler/Send', {
            assignmentid: this.props.assignmentID,
            solution: this.state.code
        }).then(response => {
            console.log(response);
        }).catch(error => {
            console.log(error.response);
        })
    }

    render() {
        let options = {
            lineNumbers: true,
            mode: 'text/x-c++src',
            theme: 'neat',
            autoCloseBrackets: true,
        };

        return (
            <div className="codingSection">
                <div className="codeArea">
                    <CodeMirror value={this.state.code} onChange={this.updateCode.bind(this)} options={options} />
                    <Button className='runbutton' onClick={this.runCodeHandler}>Run</Button>
                </div>
                <div className="output">
                    <div className="outputbox" dangerouslySetInnerHTML={this.createMarkup()}>

                    </div>
                    <Button className='sendbutton' onClick={this.sendCodeHandler}>Wyślij</Button>
                </div>
            </div>
        );
    }
}
export default Codemirror;
