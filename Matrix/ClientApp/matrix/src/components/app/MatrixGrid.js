import React, { Component } from 'react';
import './MatrixGrid.css'
export class MatrixGrid extends Component {

    constructor(props) {
        super(props);
        this.state = {
            testMatrix: [[]],
            loading: true
        }
    }

    render() {
        return (
            <div>
                {this.state.testMatrix.map((row, item) =>
                    (<div key={item}>
                        {row.map((col, element) => <span key={element}> | {col} | </span>)}
                    </div>))
                }
                <br></br>
                <div>
                    <button className="btn btn-primary" onClick={this.load}>Load from csv</button>
                    <button className="btn btn-primary" onClick={this.generate}>Generate random square matrix</button>
                    <button className="btn btn-primary" onClick={this.rotateClockWise}>Rotate clock wise</button>
                    <button className="btn btn-primary" onClick={this.rotateAntiClockWise}>Rotate anti clockwise</button>
                    <button className="btn btn-primary" onClick={this.export}>Export to csv</button>
                </div>
            </div>
        );
    }

    async rotateClockWise() {
        const response = await fetch('api\\matrix\\clockwise-rotation');
        const data = await response.json();
        this.setState({ testMatrix: data, loading: false });
    }

    async rotateAntiClockWise() {
        const response = await fetch('api\\matrix\\anti-clockwise-rotation');
        const data = await response.json();
        this.setState({ testMatrix: data, loading: false });
    }

    generate = () => {
        var customMatrix = [
            [1, 2, 3],
            [4, 5, 6],
            [7, 8, 9],
        ];
        this.setState({ testMatrix: customMatrix, loading: false });
        this.post();
    }

    async post() {
        var result = await fetch('api\\matrix\\store',
            {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ incomingMatrix: this.state.incomingMatrix })
            })
            .then(res => (res.ok ? res : Promise.reject(res)))
            .then(res => res.json());
        console.log(result);
    }
}