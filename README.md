# GraphMLWriter

# Entity Relationship Diagrams

``` csharp
var graph = new Graph();
var nodeCount = graph.AllNodes.Count;
var factory = new EntityRelationshipNodeFactory();

var employee = factory.CreateSmallEntity(nodeCount++, "Employee").SetLocation(500, 0);
var idAttribute = factory.CreatePrimaryKeyAttribute(nodeCount++, "ID").SetLocation(450, 50);
var nameAttribute = factory.CreateAttribute(nodeCount++, "Name").SetLocation(550, 50);

var project = factory.CreateSmallEntity(nodeCount++, "Project").SetLocation(800, 0);
var projectCodeAttribute = factory.CreateAttribute(nodeCount++, "ProjectCode").SetLocation(790, 50).SetSize(100, 30);
var managesRelation = factory.CreateRelationship(nodeCount, "manages").SetLocation(650, 0);

graph.AddNodes(employee, idAttribute, nameAttribute, project, projectCodeAttribute, managesRelation);

var edgeCount = graph.AllEdges.Count;
graph.AddEdges(
    new Edge(edgeCount++, employee, idAttribute) { TargetArrow = EdgeArrow.None },
    new Edge(edgeCount++, employee, nameAttribute) { TargetArrow = EdgeArrow.None },
    new Edge(edgeCount++, project, projectCodeAttribute) { TargetArrow = EdgeArrow.None },
    new Edge(edgeCount++, employee, managesRelation) { TargetArrow = EdgeArrow.None },
    new Edge(edgeCount, project, managesRelation) { TargetArrow = EdgeArrow.None }
);
```