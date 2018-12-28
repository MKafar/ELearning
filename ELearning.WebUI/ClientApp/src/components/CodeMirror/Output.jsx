import React, { Component } from 'react';
import axios from '../../axios.js';

import "./Output.scss";

class Output extends Component {
    state = {
        output: []
    }

    componentDidMount () {
        axios.get('/posts')
        .then(response => {
            const output = response.data.slice(0, 4);
            const updatedOutput = output.map(output => {
                return {
                    ...output
                }
            })
            this.setState({output: updatedOutput});
        });
    }

    render() {
        const output = this.state.output.map(output => {
            return output.id;
        });

        return (
            <div className="outputbox">
                {output}
            </div>
        )
    };
}

export default Output;