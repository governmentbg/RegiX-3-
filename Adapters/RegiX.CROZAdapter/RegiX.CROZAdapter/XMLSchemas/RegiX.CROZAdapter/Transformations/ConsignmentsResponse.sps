<?xml version="1.0" encoding="UTF-8"?>
<structure version="7" xsltversion="1" html-doctype="HTML4 Transitional" compatibility-view="IE9" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" useimportschema="1" embed-images="1" enable-authentic-scripts="1" authentic-scripts-in-debug-mode-external="0" generated-file-location="DEFAULT">
	<parameters>
		<parameter name="documentId"/>
	</parameters>
	<schemasources>
		<namespaces>
			<nspair prefix="cr" uri="http://egov.bg/RegiX/CROZ/CROZ"/>
			<nspair prefix="n1" uri="http://egov.bg/RegiX/CROZ/CROZ/ConsignmentsResponse"/>
		</namespaces>
		<schemasources>
			<xsdschemasource name="XML" main="1" schemafile="xsd_current\ConsignmentsResponse.xsd" workingxmlfile="consignmentsResponse_star_arhiven.xml"/>
		</schemasources>
	</schemasources>
	<modules/>
	<flags>
		<scripts/>
		<mainparts/>
		<globalparts/>
		<designfragments/>
		<pagelayouts/>
		<xpath-functions/>
	</flags>
	<scripts>
		<script language="javascript"/>
	</scripts>
	<script-project>
		<Project version="2" app="AuthenticView"/>
	</script-project>
	<importedxslt/>
	<globalstyles/>
	<mainparts>
		<children>
			<globaltemplate subtype="main" match="/">
				<document-properties/>
				<children>
					<documentsection>
						<properties columncount="1" columngap="0.50in" headerfooterheight="fixed" pagemultiplepages="0" pagenumberingformat="1" pagenumberingstartat="auto" pagestart="next" paperheight="11in" papermarginbottom="0.79in" papermarginfooter="0.30in" papermarginheader="0.30in" papermarginleft="0.60in" papermarginright="0.60in" papermargintop="0.79in" paperwidth="8.50in"/>
						<watermark>
							<image transparency="50" fill-page="1" center-if-not-fill="1"/>
							<text transparency="50"/>
						</watermark>
					</documentsection>
					<template subtype="source" match="XML">
						<children>
							<template subtype="element" match="n1:ConsignmentsResponse">
								<children>
									<paragraph paragraphtag="h3">
										<styles font-size="18px" text-align="center"/>
										<children>
											<text fixtext="Справка за вписвания по партида в Централния регистър на особените залози">
												<styles font-size="18px"/>
											</text>
										</children>
									</paragraph>
									<condition>
										<children>
											<conditionbranch xpath="string-length(n1:consignment) &gt; 0">
												<children>
													<paragraph>
														<styles color="black" font-size="16px" text-align="center"/>
														<children>
															<condition>
																<children>
																	<conditionbranch xpath="n1:archiveLikeFilter = &quot;ALL&quot;">
																		<children>
																			<text fixtext="(с включени архивирани вписвания)">
																				<styles font-size="16px" font-weight="bold"/>
																			</text>
																		</children>
																	</conditionbranch>
																	<conditionbranch>
																		<children>
																			<text fixtext="("/>
																			<text fixtext="само действащи вписвания)">
																				<styles font-size="16px" font-weight="bold"/>
																			</text>
																		</children>
																	</conditionbranch>
																</children>
															</condition>
														</children>
													</paragraph>
												</children>
											</conditionbranch>
										</children>
									</condition>
									<newline/>
									<template subtype="element" match="n1:synchronizationDate">
										<children>
											<content subtype="regular">
												<styles font-style="italic"/>
											</content>
											<newline/>
											<newline/>
										</children>
										<variables/>
									</template>
									<condition>
										<children>
											<conditionbranch xpath="string-length(n1:consignment) = 0">
												<children>
													<text fixtext="Не са открити данни по посочените критерии за търсене."/>
												</children>
											</conditionbranch>
										</children>
									</condition>
									<template subtype="element" filter="string-length(.) &gt; 0" match="n1:consignment">
										<children>
											<text fixtext="Партида на лицето, посочено с: ">
												<styles font-size="16px"/>
											</text>
											<newline/>
											<template subtype="element" match="cr:consignment_number">
												<children>
													<text fixtext="№ ">
														<styles font-size="16px"/>
													</text>
													<content subtype="regular">
														<styles font-size="16px" font-weight="bold"/>
													</content>
												</children>
												<variables/>
											</template>
											<newline/>
											<paragraph>
												<styles margin-left="0.5cm"/>
												<children>
													<template subtype="element" match="cr:consignmentParticipants">
														<children>
															<template subtype="element" match="cr:participant">
																<children>
																	<condition>
																		<children>
																			<conditionbranch xpath="position() &gt; 1">
																				<children>
																					<newline/>
																				</children>
																			</conditionbranch>
																		</children>
																	</condition>
																	<template subtype="element" match="cr:particip_id_code">
																		<children>
																			<text fixtext="Идентификационен код: ">
																				<styles font-size="16px" margin-left="0,5cm"/>
																			</text>
																			<content subtype="regular">
																				<styles font-size="16px" font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<newline/>
																	<text fixtext="име:">
																		<styles font-size="16px" margin-left="1cm"/>
																	</text>
																	<text fixtext=" ">
																		<styles font-size="16px"/>
																	</text>
																	<template subtype="element" match="cr:full_name">
																		<children>
																			<content subtype="regular">
																				<styles font-size="16px" font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<newline/>
																	<text fixtext="адрес: ">
																		<styles font-size="16px" margin-left="1cm"/>
																	</text>
																	<template subtype="element" match="cr:zip">
																		<children>
																			<content subtype="regular">
																				<styles font-size="16px" font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<condition>
																		<children>
																			<conditionbranch xpath="string-length( cr:zip )&gt;0">
																				<children>
																					<text fixtext=", ">
																						<styles font-size="16px" font-weight="bold"/>
																					</text>
																				</children>
																			</conditionbranch>
																		</children>
																	</condition>
																	<template subtype="element" match="cr:city">
																		<children>
																			<content subtype="regular">
																				<styles font-size="16px" font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<condition>
																		<children>
																			<conditionbranch xpath="string-length( cr:zip)&gt; 0 or string-length( cr:city)&gt;0">
																				<children>
																					<text fixtext=", ">
																						<styles font-size="16px" font-weight="bold"/>
																					</text>
																				</children>
																			</conditionbranch>
																		</children>
																	</condition>
																	<template subtype="element" match="cr:address">
																		<children>
																			<content subtype="regular">
																				<styles font-size="16px" font-weight="bold"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																</children>
																<variables/>
															</template>
														</children>
														<variables/>
													</template>
												</children>
											</paragraph>
											<newline/>
											<condition>
												<children>
													<conditionbranch xpath="count( cr:consignEntries/cr:consignEntries )&gt;0">
														<children>
															<text fixtext="Съдържа следните вписвания:">
																<styles font-size="16px"/>
															</text>
														</children>
													</conditionbranch>
													<conditionbranch>
														<children>
															<text fixtext="Не съдържа вписвания">
																<styles font-size="16px"/>
															</text>
														</children>
													</conditionbranch>
												</children>
											</condition>
											<template subtype="element" match="cr:consignEntries">
												<children>
													<template subtype="element" match="cr:consignEntries">
														<children>
															<newline/>
															<condition>
																<children>
																	<conditionbranch xpath="count(preceding-sibling::cr:consignEntries[cr:scanned=&apos;N&apos;])=0 and cr:scanned=&apos;N&apos;">
																		<children>
																			<text fixtext="Внимание! Информацията е актуална до момента преди:">
																				<styles font-size="16px"/>
																			</text>
																			<newline/>
																		</children>
																	</conditionbranch>
																</children>
															</condition>
															<newline/>
															<autocalc xpath="position()">
																<styles font-size="16px" font-weight="bold"/>
															</autocalc>
															<text fixtext=". ">
																<styles font-size="16px" font-weight="bold"/>
															</text>
															<condition>
																<children>
																	<conditionbranch xpath="cr:archived = &quot;N&quot;">
																		<children>
																			<text fixtext="Вписване">
																				<styles font-size="16px"/>
																			</text>
																		</children>
																	</conditionbranch>
																	<conditionbranch>
																		<children>
																			<text fixtext="Архивирано ">
																				<styles font-size="16px" font-weight="bold"/>
																			</text>
																			<text fixtext="вписване ">
																				<styles font-size="16px"/>
																			</text>
																		</children>
																	</conditionbranch>
																</children>
															</condition>
															<text fixtext="  ">
																<styles font-size="16px" font-weight="bold"/>
															</text>
															<template subtype="element" match="cr:regId">
																<children>
																	<text fixtext="№ ">
																		<styles font-size="16px"/>
																	</text>
																	<content subtype="regular">
																		<styles font-size="16px" font-weight="bold"/>
																	</content>
																	<text fixtext=",">
																		<styles font-size="16px"/>
																	</text>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="cr:description">
																<children>
																	<text fixtext=" ">
																		<styles font-size="16px"/>
																	</text>
																	<content subtype="regular">
																		<styles font-size="16px" font-weight="bold"/>
																	</content>
																</children>
																<variables/>
															</template>
															<condition>
																<children>
																	<conditionbranch xpath="cr:scanned = &quot;N&quot;">
																		<children>
																			<newline/>
																			<text fixtext="Въвеждането на информация по това вписване не е завършено!">
																				<styles font-size="16px" margin-left="0,5cm"/>
																			</text>
																		</children>
																	</conditionbranch>
																</children>
															</condition>
															<condition>
																<children>
																	<conditionbranch xpath="cr:status = &quot;C&quot;">
																		<children>
																			<newline/>
																			<text fixtext="Вписването ">
																				<styles font-size="16px" margin-left="0.5cm"/>
																			</text>
																			<text fixtext="е ">
																				<styles font-size="16px" font-weight="bold"/>
																			</text>
																			<text fixtext="условно.">
																				<styles font-size="16px"/>
																			</text>
																		</children>
																	</conditionbranch>
																	<conditionbranch>
																		<children>
																			<newline/>
																			<text fixtext="Вписването ">
																				<styles font-size="16px" margin-left="0.5cm"/>
																			</text>
																			<text fixtext="не е">
																				<styles font-size="16px" font-weight="bold"/>
																			</text>
																			<text fixtext=" условно.">
																				<styles font-size="16px"/>
																			</text>
																		</children>
																	</conditionbranch>
																</children>
															</condition>
															<newline/>
															<text fixtext="Дата и час на вписването: ">
																<styles font-size="16px" margin-left="0.5cm"/>
															</text>
															<template subtype="element" match="cr:reg_date">
																<children>
																	<content subtype="regular">
																		<styles font-size="16px" font-weight="bold"/>
																	</content>
																</children>
																<variables/>
															</template>
															<template subtype="element" match="cr:reg_time">
																<children>
																	<text fixtext=" ">
																		<styles font-size="16px" font-weight="bold"/>
																	</text>
																	<content subtype="regular">
																		<styles font-size="16px" font-weight="bold"/>
																	</content>
																</children>
																<variables/>
															</template>
															<newline/>
															<template subtype="element" match="cr:creditors">
																<children>
																	<text fixtext="Вписаните права са на:">
																		<styles font-size="16px" margin-left="0.5cm"/>
																	</text>
																	<paragraph>
																		<styles margin-left="1cm"/>
																		<children>
																			<template subtype="element" match="cr:consignCreditors">
																				<children>
																					<autocalc xpath="position()">
																						<styles font-size="16px" font-weight="bold"/>
																					</autocalc>
																					<text fixtext=".">
																						<styles font-size="16px" font-weight="bold"/>
																					</text>
																					<text fixtext=" ">
																						<styles font-size="16px"/>
																					</text>
																					<template subtype="element" match="cr:participant">
																						<children>
																							<template subtype="element" match="cr:particip_id_code">
																								<children>
																									<text fixtext="Идентификационен код: ">
																										<styles font-size="16px"/>
																									</text>
																									<content subtype="regular">
																										<styles font-size="16px" font-weight="bold"/>
																									</content>
																									<text fixtext=",">
																										<styles font-size="16px"/>
																									</text>
																								</children>
																								<variables/>
																							</template>
																							<template subtype="element" match="cr:full_name">
																								<children>
																									<text fixtext=" ">
																										<styles font-size="16px" font-weight="bold"/>
																									</text>
																									<content subtype="regular">
																										<styles font-size="16px" font-weight="bold"/>
																									</content>
																									<text fixtext=", ">
																										<styles font-size="16px" font-weight="bold"/>
																									</text>
																								</children>
																								<variables/>
																							</template>
																							<template subtype="element" match="cr:zip">
																								<children>
																									<text fixtext=" ">
																										<styles font-size="16px" font-weight="bold"/>
																									</text>
																									<content subtype="regular">
																										<styles font-size="16px" font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																							<condition>
																								<children>
																									<conditionbranch xpath="string-length( cr:zip )&gt;0">
																										<children>
																											<text fixtext=", ">
																												<styles font-size="16px" font-weight="bold"/>
																											</text>
																										</children>
																									</conditionbranch>
																								</children>
																							</condition>
																							<template subtype="element" match="cr:city">
																								<children>
																									<content subtype="regular">
																										<styles font-size="16px" font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																							<condition>
																								<children>
																									<conditionbranch xpath="string-length( cr:zip )&gt; 0 or string-length( cr:city )">
																										<children>
																											<text fixtext=", ">
																												<styles font-size="16px" font-weight="bold"/>
																											</text>
																										</children>
																									</conditionbranch>
																								</children>
																							</condition>
																							<template subtype="element" match="cr:address">
																								<children>
																									<content subtype="regular">
																										<styles font-size="16px" font-weight="bold"/>
																									</content>
																								</children>
																								<variables/>
																							</template>
																							<newline/>
																						</children>
																						<variables/>
																					</template>
																					<paragraph>
																						<styles margin-left="0.5cm"/>
																						<children>
																							<text fixtext="Вписано пристъпване към изпълнение: ">
																								<styles font-size="16px"/>
																							</text>
																							<condition>
																								<children>
																									<conditionbranch xpath="count( cr:proceedexecutionDates/cr:dates )=0">
																										<children>
																											<text fixtext="НЕ ;">
																												<styles font-size="16px" font-weight="bold"/>
																											</text>
																										</children>
																									</conditionbranch>
																									<conditionbranch>
																										<children>
																											<template subtype="element" match="cr:proceedexecutionDates">
																												<children>
																													<template subtype="element" match="cr:dates">
																														<children>
																															<content subtype="regular">
																																<styles font-size="16px" font-weight="bold"/>
																															</content>
																															<text fixtext=";">
																																<styles font-size="16px" font-weight="bold"/>
																															</text>
																															<text fixtext=" ">
																																<styles font-size="16px"/>
																															</text>
																														</children>
																														<variables/>
																													</template>
																												</children>
																												<variables/>
																											</template>
																										</children>
																									</conditionbranch>
																								</children>
																							</condition>
																							<template subtype="element" match="cr:proceedexecutionDates">
																								<variables/>
																							</template>
																							<newline/>
																							<text fixtext="Вписано изоставяне на изпълнение: ">
																								<styles font-size="16px"/>
																							</text>
																							<condition>
																								<children>
																									<conditionbranch xpath="count( cr:leftExecutionDates/cr:dates )=0">
																										<children>
																											<text fixtext="НЕ ;">
																												<styles font-size="16px" font-weight="bold"/>
																											</text>
																										</children>
																									</conditionbranch>
																									<conditionbranch>
																										<children>
																											<template subtype="element" match="cr:leftExecutionDates">
																												<children>
																													<template subtype="element" match="cr:dates">
																														<children>
																															<content subtype="regular">
																																<styles font-size="16px" font-weight="bold"/>
																															</content>
																															<text fixtext="; ">
																																<styles font-size="16px" font-weight="bold"/>
																															</text>
																														</children>
																														<variables/>
																													</template>
																												</children>
																												<variables/>
																											</template>
																										</children>
																									</conditionbranch>
																								</children>
																							</condition>
																							<newline/>
																							<text fixtext="Заличаване на вписването: ">
																								<styles font-size="16px"/>
																							</text>
																							<condition>
																								<children>
																									<conditionbranch xpath="count( cr:eraseExecutionDates/cr:dates )=0">
																										<children>
																											<text fixtext="НЕ ;">
																												<styles font-size="16px" font-weight="bold"/>
																											</text>
																										</children>
																									</conditionbranch>
																									<conditionbranch>
																										<children>
																											<template subtype="element" match="cr:eraseExecutionDates">
																												<children>
																													<template subtype="element" match="cr:dates">
																														<children>
																															<content subtype="regular">
																																<styles font-size="16px" font-weight="bold"/>
																															</content>
																															<text fixtext="; ">
																																<styles font-size="16px" font-weight="bold"/>
																															</text>
																														</children>
																														<variables/>
																													</template>
																												</children>
																												<variables/>
																											</template>
																										</children>
																									</conditionbranch>
																								</children>
																							</condition>
																						</children>
																					</paragraph>
																				</children>
																				<variables/>
																			</template>
																		</children>
																	</paragraph>
																</children>
																<variables/>
															</template>
															<paragraph>
																<styles margin-left="0.5cm"/>
																<children>
																	<template subtype="element" match="cr:page_numbers">
																		<children>
																			<text fixtext="Описание на имуществото и друга информация за вписването: Оптичен архив състоящ се от ">
																				<styles font-size="16px"/>
																			</text>
																			<content subtype="regular">
																				<styles font-size="16px" font-weight="bold"/>
																				<format basic-type="xsd" datatype="int"/>
																			</content>
																			<text fixtext=" страници;">
																				<styles font-size="16px"/>
																			</text>
																		</children>
																		<variables/>
																	</template>
																	<newline/>
																	<text fixtext="Покана за назначаване на нов управител: ">
																		<styles font-size="16px"/>
																	</text>
																	<condition>
																		<children>
																			<conditionbranch xpath="count(cr:newManagerDates/cr:dates )=0">
																				<children>
																					<text fixtext="НЕ ;">
																						<styles font-size="16px" font-weight="bold"/>
																					</text>
																				</children>
																			</conditionbranch>
																			<conditionbranch>
																				<children>
																					<template subtype="element" match="cr:newManagerDates">
																						<children>
																							<template subtype="element" match="cr:dates">
																								<children>
																									<content subtype="regular">
																										<styles font-size="16px" font-weight="bold"/>
																									</content>
																									<text fixtext="; ">
																										<styles font-size="16px" font-weight="bold"/>
																									</text>
																								</children>
																								<variables/>
																							</template>
																						</children>
																						<variables/>
																					</template>
																				</children>
																			</conditionbranch>
																		</children>
																	</condition>
																	<newline/>
																	<condition>
																		<children>
																			<conditionbranch xpath="cr:retId = &apos;01&apos;">
																				<children>
																					<text fixtext="Регистрационни номера на вписани запори върху обезпеченото вземане: ">
																						<styles font-size="16px"/>
																					</text>
																					<condition>
																						<children>
																							<conditionbranch xpath="count( cr:distrainSecuredClaims/cr:distrainSecuredClaim )=0">
																								<children>
																									<text fixtext="НЕ">
																										<styles font-size="16px" font-weight="bold"/>
																									</text>
																								</children>
																							</conditionbranch>
																							<conditionbranch>
																								<children>
																									<template subtype="element" match="cr:distrainSecuredClaims">
																										<children>
																											<template subtype="element" match="cr:distrainSecuredClaim">
																												<children>
																													<newline/>
																													<content subtype="regular">
																														<styles font-size="16px" font-weight="bold" margin-left="1.5cm"/>
																													</content>
																												</children>
																												<variables/>
																											</template>
																										</children>
																										<variables/>
																									</template>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
																				</children>
																			</conditionbranch>
																			<conditionbranch xpath="cr:retId = &apos;04&apos;">
																				<children>
																					<text fixtext="Регистрационен номер на залог върху вземане: ">
																						<styles font-size="16px"/>
																					</text>
																					<condition>
																						<children>
																							<conditionbranch xpath="string-length(cr:pledgeOnClaim)=0">
																								<children>
																									<text fixtext="НЕ">
																										<styles font-size="16px" font-weight="bold"/>
																									</text>
																								</children>
																							</conditionbranch>
																							<conditionbranch>
																								<children>
																									<template subtype="element" match="cr:pledgeOnClaim">
																										<children>
																											<content subtype="regular">
																												<styles font-size="16px" font-weight="bold"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
																				</children>
																			</conditionbranch>
																		</children>
																	</condition>
																	<template subtype="element" match="cr:expire_date">
																		<children>
																			<newline/>
																			<text fixtext="Дата, на която се прекратява действието на вписването: ">
																				<styles font-size="16px"/>
																			</text>
																			<content subtype="regular">
																				<styles font-size="16px" font-weight="bold"/>
																				<format basic-type="xsd" datatype="string"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																</children>
															</paragraph>
															<paragraph>
																<styles font-size="16px"/>
																<children>
																	<template subtype="element" filter="string-length(../cr:oa_pole17)&gt;0" match="cr:opis_header">
																		<children>
																			<newline/>
																			<content subtype="regular">
																				<styles font-size="16px" font-weight="bold" margin-left="0.5cm"/>
																			</content>
																		</children>
																		<variables/>
																	</template>
																	<template subtype="element" match="cr:oa_pole17">
																		<children>
																			<template subtype="element" match="cr:oas">
																				<children>
																					<condition>
																						<children>
																							<conditionbranch xpath="string-length(../../cr:opis_header) &gt; 0">
																								<children>
																									<template subtype="element" match="cr:regId">
																										<children>
																											<text fixtext=" ">
																												<styles font-size="16px" font-weight="bold"/>
																											</text>
																											<content subtype="regular">
																												<styles font-size="16px" font-weight="bold"/>
																											</content>
																										</children>
																										<variables/>
																									</template>
																								</children>
																							</conditionbranch>
																						</children>
																					</condition>
																					<template subtype="element" match="cr:imgFace">
																						<children>
																							<newline/>
																							<image>
																								<styles font-size="16px"/>
																								<target>
																									<xpath value="concat(&quot;data:&quot;, ../cr:imgFaceType, &quot;;base64,&quot;, string(.))"/>
																								</target>
																							</image>
																						</children>
																						<variables/>
																					</template>
																					<template subtype="element" match="cr:imgBack">
																						<children>
																							<newline/>
																							<image>
																								<styles font-size="16px"/>
																								<target>
																									<xpath value="concat(&quot;data:&quot;, ../cr:imgBackType, &quot;;base64,&quot;, string(.))"/>
																								</target>
																							</image>
																						</children>
																						<variables/>
																					</template>
																				</children>
																				<variables/>
																			</template>
																		</children>
																		<variables/>
																	</template>
																</children>
															</paragraph>
															<newline/>
															<text fixtext="Допълнителни вписвания: ">
																<styles font-size="16px" margin-left="0.5cm"/>
															</text>
															<condition>
																<children>
																	<conditionbranch xpath="cr:amd_numbers &gt; 0">
																		<children>
																			<template subtype="element" match="cr:amd_numbers">
																				<children>
																					<content subtype="regular">
																						<styles font-size="16px" font-weight="bold"/>
																						<format basic-type="xsd" datatype="int"/>
																					</content>
																				</children>
																				<variables/>
																			</template>
																		</children>
																	</conditionbranch>
																	<conditionbranch>
																		<children>
																			<text fixtext="Няма">
																				<styles font-size="16px" font-weight="bold"/>
																			</text>
																		</children>
																	</conditionbranch>
																</children>
															</condition>
														</children>
														<variables/>
													</template>
												</children>
												<variables/>
											</template>
										</children>
										<variables/>
									</template>
								</children>
								<variables/>
							</template>
						</children>
						<variables/>
					</template>
					<newline/>
				</children>
			</globaltemplate>
		</children>
	</mainparts>
	<globalparts/>
	<designfragments/>
	<xmltables/>
	<authentic-custom-toolbar-buttons/>
</structure>
