# Add kubernetes-dashboard repository
helm repo add kubernetes-dashboard https://kubernetes.github.io/dashboard/
# Deploy a Helm Release named "kubernetes-dashboard" using the kubernetes-dashboard chart
helm upgrade --install kubernetes-dashboard kubernetes-dashboard/kubernetes-dashboard --create-namespace --namespace kubernetes-dashboard
 # open the dashboard port 
 kubectl -n kubernetes-dashboard port-forward svc/kubernetes-dashboard-kong-proxy 8443:443
# 

# create service account for dashabord  
kubectl create serviceaccount dashboard-user --namespace=kubernetes-dashboard

# give role admin 
 kubectl create clusterrolebinding dashboard-user-cluster-admin-binding --clusterrole=cluster-admin --serviceaccount=kubernetes-dashboard:dashboard-user

# get the token 
kubectl -n kubernetes-dashboard create token dashboard-user

-----------------------------

# install ngnix controller via helm 
 helm upgrade --install ingress-nginx ingress-nginx   --repo https://kubernetes.github.io/ingress-nginx   --namespace ingress-nginx --create-namespace

 ---------------
 
  # return cluster service accounts 
 kubectl get serviceAccounts
 
 #deploy api
$ kubectl apply -f deploy-api1.yaml

