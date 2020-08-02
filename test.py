import plotly.offline as py
import plotly.graph_objects as go


trace = go.Scatter3d(
    x=[1,2,3],
    y=[1,2,3],
    z=[1,2,3],
    name='3d',
    mode='markers'
)

py.plot([trace])