<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="n1" uri="http://egov.bg/RegiX/Iaaa/VehicleInspections/VehicleInspectionRequest"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="..\Report4_vehicleInspectionRequest.xsd" workingxmlfile="Report4_vehicleInspectionRequest.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<paragraph paragraphtag="h3">								<properties align="center"/>								<children>									<text fixtext="Входни параметри на справка за извършен технически преглед по регистрационен номер на автомобил"/>								</children>							</paragraph>							<template match="n1:VehicleInspectionRequest" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<table>										<properties border="0"/>										<children>											<tablebody>												<children>													<tablerow>														<children>															<tablecell headercell="1">																<children>																	<text fixtext="Регистрационен номер:">																		<styles font-style="italic" font-weight="normal"/>																	</text>																</children>															</tablecell>															<tablecell>																<children>																	<template match="n1:RegNumber" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<styles font-weight="bold"/>																				<format datatype="string"/>																			</content>																		</children>																	</template>																</children>															</tablecell>														</children>													</tablerow>												</children>											</tablebody>										</children>									</table>								</children>							</template>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>